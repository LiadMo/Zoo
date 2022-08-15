using System;
using System.Collections.Generic;
using System.Threading;


namespace Zoo
{
    internal class program
    {
        static void Main(string[] args)
        {
            int milliseconds = 500;
            var zoo = new Zoo(milliseconds);
            var zoo2 = new Zoo(milliseconds);


            var a1 = new Elephant("pil");
            var a2 = new Elephant("fil");

            zoo.AddAnimal("Elefent","Yosi");
            zoo.AddAnimal(a2);
            zoo.ClearZoo();

            zoo.RunZoo();

        }
    }
}
