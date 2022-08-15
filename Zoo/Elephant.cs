using System;
namespace Zoo {
    internal class Elephant : Animal {
        public Elephant(string name) {
            Name = name;
            Species = "Elephant";
            AnimalChar = Species[0];
            Cord = new Point(0, 0);
            Steps = 2;

        }

        public override void AnimalSound() {
            Console.WriteLine("Whohohohooh - Elephant sound");
        }
    }
}
