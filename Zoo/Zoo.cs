using System;
using System.Collections.Generic;
using System.Threading;

namespace Zoo
{
    internal class Zoo
    {
        int _delay;
        public List<IAnimal> _animals { get; set; }
        Canvas canvas;

        public Zoo(int delay, int width = 110, int height = 25)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Negativ|zero width OR height");
            }

            _delay = delay;
            _animals = new List<IAnimal>();
            canvas = Canvas.CreateCanvas(width, height);
        }

        public void AddAnimal(Animal animal)
        {
            if (animal == null)
            {
                throw (new ArgumentException("Null animal argument"));
            }
            Random random = new Random();
            int x = random.Next(0, canvas._width + 1);
            int y = random.Next(0, canvas._height + 1);
            animal._cord.UpdatePoint(x, y);
            _animals.Add(animal);
        }

        public void RunZoo()
        {
            var frame = Canvas.CreateCanvas();

            if (canvas == null)
            {
                throw (new ArgumentException("Canvas error"));
            }
            frame.DrawCanvas();


            while (frame != null)
            {
                // frame.DrawCanvas();
                foreach (var animal in _animals)
                {
                    animal.Draw();
                    animal.Walk(canvas._width, canvas._height);
                }
                Thread.Sleep(_delay);
            }
        }

        public void ClearZoo()
        {
            Console.Clear();
            canvas = null;
            _animals.Clear();
        }
    }
}

