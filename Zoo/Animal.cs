using System;
using System.Threading;
namespace Zoo {
    abstract class Animal : IAnimal {
        #region public properties
        public Point Cord { get; init; }
        public string Name { get; init; }
        public string Species { get; init; }
        public char AnimalChar { get; init; }
        public int Steps { get; init; }
        public Timer Time { get; init; }
        public int Happines { get; set; }
        #endregion


        /// <summary>
        /// draw the animal (char) to the console (in is location)
        /// </summary>
        public void Draw() {
            Console.SetCursorPosition(Cord.X, Cord.Y);
            Console.Write(AnimalChar);
        }

        /// <summary>
        /// update the animal location (randomly, with the limit step)
        /// </summary>
        /// <param name="max_x">the width of the frame</param>
        /// <param name="max_y">the height of the frame</param>
        public virtual void Walk(int max_x, int max_y) {
            var random = new Random();

            int x_to_add = random.Next(-Steps, Steps + 1);
            int y_to_add = random.Next(-Steps, Steps + 1);
            Cord.UpdatePoint(x_to_add, y_to_add);
            if (!Cord.IsValidPoint(max_x, max_y)) {
                Cord.UpdatePoint(-x_to_add, -y_to_add);
            }
        }

        protected void Sad() {
            Happines -= 1;
        }

        /// <summary>
        /// format: "{name} is a {species} and is sound like {animal sound}"
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return Name + " is a " + Species + " and is sound like " + AnimalSound();
        }

        /// <summary>
        /// return the string of the animal sound
        /// </summary>
        /// <returns></returns>
        public abstract string AnimalSound();
    }
}
