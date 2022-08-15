using System;
namespace Zoo {
    abstract class Animal : IAnimal {
        #region public properties
        public Point Cord { get; init; }
        public string Name { get; init; }
        public string Species { get; init; }
        public char AnimalChar { get; init; }
        public int Steps { get; init; }
        //protected double _age;
        //protected double _weight;
        //protected int _happines;
        #endregion

        public void Draw() {
            Console.SetCursorPosition(Cord.X, Cord.Y);
            Console.Write(AnimalChar);
        }

        public void Walk(int max_x, int max_y) {
            var random = new Random();

            int x_to_add = random.Next(-Steps, Steps + 1);
            int y_to_add = random.Next(-Steps, Steps + 1);
            Cord.UpdatePoint(x_to_add, y_to_add);
            if (!Cord.IsValidPoint(max_x, max_y)) {
                Cord.UpdatePoint(-x_to_add, -y_to_add);
            }
        }

        public abstract void AnimalSound();
    }
}
