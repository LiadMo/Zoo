namespace Zoo {
    internal class Program {
        static void Main(string[] args) {
            int milliseconds = 10;
            var zoo = new Zoo(milliseconds);

            var a1 = new Elephant("pil");
            var a2 = new Elephant("fil");

            zoo.AddAnimal(a1);
            zoo.AddAnimal(a2);

            zoo.RunZoo();

        }
    }
}
