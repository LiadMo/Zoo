using System;
using System.Collections.Generic;
using System.Threading;

namespace Zoo {
    internal class Zoo {
        #region public properties
        public List<IAnimal> Animals { get; init; }
        private int _delay;
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
        private void AddAnimal(Animal animal) {
            if (animal == null) {
                throw (new ArgumentException("Null animal argument"));
            }
            Random random = new Random();
            int x = random.Next(0, _canvas.Width + 1);
            int y = random.Next(0, _canvas.Height + 1);
            animal.Cord.UpdatePoint(x, y);
            Animals.Add(animal);
        }

        /// <summary>
        /// print all anumals in the zoo
        /// </summary>
        private void PrintAnimals() {
            foreach (var animal in Animals) {
                Console.WriteLine(animal.ToString());
            }
            Console.WriteLine();
        }

        /// <summary>
        /// remove all anumals from the zoo
        /// </summary>
        private void ClearAnimals() {
            Animals.Clear();
        }

        public void RunZoo() {
            Console.WriteLine("Welcome to the Safari\n Options:\n 1) add an animal\n 2) remove all animals from the zoo\n 3) print all animals in the zoo\n 4) run zoo - to exit fron the run, press Q\n");
            string choise = Console.ReadLine();
            switch (choise) {
                case "1":
                    Console.WriteLine("please enter the type of animal to add - Elephant \\ Lion \\ Tiger \\ Panda");
                    string type = Console.ReadLine();
                    Console.WriteLine("please enter the animal name: ");
                    string name = Console.ReadLine();

                    Animal to_add = null;
                    try {
                        to_add = AnimalFactory.MakeAnimal(type, name);
                    } catch (Exception ex) {
                        Console.WriteLine(ex.Message + "\n");
                        RunZoo();
                        break;
                    }


                    AddAnimal(to_add);
                    Console.WriteLine("Animal successfully added !\n\n");
                    RunZoo();
                    break;

                case "2":
                    ClearAnimals();
                    RunZoo();
                    break;

                case "3":
                    PrintAnimals();
                    RunZoo();
                    break;

                case "4":
                    while (_canvas != null) {
                        _canvas.DrawCanvas();
                        foreach (var animal in Animals) {
                            animal.Draw();
                            animal.Walk(_canvas.Width, _canvas.Height);
                        }
                        Thread.Sleep(_delay);
                    }
                    break;
            }
        }
        #endregion
    }
}

