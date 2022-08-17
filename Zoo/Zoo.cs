using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;

namespace Zoo {
    class Zoo {
        #region public properties
        public List<IAnimal> Animals { get; init; }
        private List<Point> _points;
        private int _delay;
        private readonly Canvas _canvas;
        private string _availableAnimals;
        #endregion

        public Zoo(int delay = 100, int width = 110, int height = 25) {
            if (width <= 0 || height <= 0) {
                throw new ArgumentException("Negativ|zero width OR height");
            }

            _delay = delay;
            Animals = new List<IAnimal>();
            _points = new List<Point>();
            _canvas = Canvas.CreateCanvas(width, height);
            _availableAnimals = ConfigurationManager.AppSettings["Animals"];
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
            if (Animals.Count == 0) {
                Console.WriteLine("There are no animals in the zoo");
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
            //Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to the Safari\n Options:\n 1) add an animal\n 2) remove all animals from the zoo\n 3) print all animals in the zoo\n 4) run zoo - to exit fron the run, press Q\n");
            Console.ResetColor();
            string choise = Console.ReadLine();
            switch (choise) {
                case "1":
                    Console.WriteLine("please enter the type of animal to add - " + _availableAnimals);
                    string type = Console.ReadLine().ToLower();
                    Console.WriteLine("please enter the animal name: ");
                    string name = Console.ReadLine();

                    Animal to_add = null;
                    try {
                        to_add = AnimalFactory.MakeAnimal(type, name);
                    } catch (Exception ex) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message + "\n");
                        Console.ResetColor();
                        RunZoo();
                        break;
                    }


                    AddAnimal(to_add);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Animal successfully added !\n\n");
                    Console.ResetColor();
                    RunZoo();
                    break;

                case "2":
                    ClearAnimals();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("All animals were successfully removed\n");
                    Console.ResetColor();
                    RunZoo();
                    break;

                case "3":
                    PrintAnimals();
                    RunZoo();
                    break;

                case "4":
                    Console.CursorVisible = false;
                    while (_canvas != null) {
                        _canvas.DrawCanvas();
                        foreach (Animal animal in Animals) {

                            animal.Draw();

                            //_points.Add(animal.Cord);
                            animal.Walk(_canvas.Width, _canvas.Height);
                        }
                        Thread.Sleep(_delay);

                        foreach (var point in _points) {
                            //Console.SetCursorPosition(point.X - 1, point.Y);
                            //Console.Write("\b");
                            //Console.WriteLine(point);
                            //Console.Write("X");
                            //Console.Write(point.X);
                            //Console.SetCursorPosition(point.X, point.Y);
                            //Console.Write("Z");
                        }
                        //Console.WriteLine(_points.Count);
                        //_points.Clear();
                        //Console.WriteLine(_points.Count);

                    }
                    Console.CursorVisible = true;
                    break;
            }
        }
        #endregion
    }
}

