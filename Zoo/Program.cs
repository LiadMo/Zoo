namespace Zoo {
    internal class Program {
        static void Main(string[] args) {

            int milliseconds = 500;
            var zoo = new Zoo(milliseconds);
            zoo.RunZoo();
        }
    }
}
