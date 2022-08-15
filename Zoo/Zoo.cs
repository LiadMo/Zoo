using System;
using System.Collections.Generic;
using System.Threading;

namespace Zoo {
    internal class Zoo {
        #region public properties
        private int _delay;
        public List<IAnimal> Animals { get; init; }
        private readonly Canvas _canvas;
        #endregion

        public Zoo(int delay = 100, int width = 110, int height = 25) {
            if (width <= 0 || height <= 0) {
                throw new ArgumentException("Negativ|zero width OR height");
            }

            _delay = delay;
            Animals = new List<IAnimal>();
            _canvas = Canvas.CreateCanvas(width, height);
        }

        #region methods
        /// <summary>
        /// add an animal to the zoo
        /// </summary>
        /// <param name="animal"></param>
        public void AddAnimal(Animal animal) {
            if (animal == null) {
                throw (new ArgumentException("Null animal argument"));
            }
            Random random = new Random();
            int x = random.Next(0, _canvas.Width + 1);
            int y = random.Next(0, _canvas.Height + 1);
            animal.Cord.UpdatePoint(x, y);
            Animals.Add(animal);
        }


        public void RunZoo() {
            while (_canvas != null) {
                _canvas.DrawCanvas();
                foreach (var animal in Animals) {
                    animal.Draw();
                    animal.Walk(_canvas.Width, _canvas.Height);
                }
                Thread.Sleep(_delay);
            }
        }

        /// <summary>
        /// remove all anumals from the zoo
        /// </summary>
        public void ClearAnimals() {
            Animals.Clear();
        }
        #endregion
    }
}

