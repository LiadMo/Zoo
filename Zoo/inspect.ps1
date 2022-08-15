param(
    [Parameter(Mandatory=$true)]
    [string]$solutionFilePath,    
    [Parameter(Mandatory=$false)]
    [switch]$includeAllFiles
)
function ExitWithCode($exitcode) {
    $host.SetShouldExit($exitcode)
    exit $exitcode
}
$ScriptRoot = Split-Path $script:MyInvocation.MyCommand.Path
$profile = "$ScriptRoot\ibi.DotSettings"
$solutionFile=Get-Item $solutionFilePath

Write-Host("Using solution at", $solutionFile)

$reportFile = "$env:TEMP\$($solutionFile.Basename)_report.xml"
Write-Host("Using report file at", $reportFile)



if ($includeAllFiles) {
    $changes = git ls-tree -r --full-name --name-only HEAD | Where-Object { $_ -match "\.cs$" }
}
else {
    $status = git status
    $isDetached = $status[0].Contains("HEAD detached at")
    if($isDetached){
        $commits = git log --simplify-by-decoration --format="%H" -2
        $compareWith=$commits[1]
        Write-Host("Comparing detached head against latest parent branch commit $compareWith ...")
    }else{
        $compareWith = git rev-parse --abbrev-ref origin/HEAD
        Write-Host("Comparing against main branch  $compareWith ..." )
    }
    $changes = git diff --name-only --diff-filter=AMRU $compareWith  -- *.cs


}

if ($changes.Length -eq 0) {
    Write-Host("No changes detected");
    exit(0)
}

Write-Host("The following files will be scanned:" )
Write-Host("")
$changes
Write-Host("")

$changedFiles = $changes -join ";"

jb inspectcode `
 --caches-home="$env:TEMP\$($solutionFile.Basename)_InspectCache" `
 --output=$reportFile `
 --format=Xml `
 --severity=ERROR `
 --no-build `
 --include=$changedFiles `
 --verbosity=ERROR `
 --no-swea `
 --profile=$profile `
 --no-buildin-settings `
 $solutionFilePath

Write-Host("")

[System.Xml.XmlDocument] $report = New-Object System.Xml.XmlDocument
$report.load($reportFile)

$found_issues = Select-Xml -Xml $report -XPath '/Report/Issues/Project/Issue'



if ($found_issues.count -eq 0){
    Write-Host("Well done. Lets' commit!")
    ExitWithCode 0
}
else {
    $found_issues | ForEach-Object {
        $file=$_.Node.File
        $line=$_.Node.Line
        $msg=$_.Node.Message
        '{0}({1}): {2}' -f $file.Replace('\','/'), $line,  $msg
    }
    Write-Host("")
    Write-Host("Not so fast, buddy... You have some work to do!")
    ExitWithCode 1
}
