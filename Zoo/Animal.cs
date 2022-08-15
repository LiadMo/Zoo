using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    abstract class Animal : IAnimal {
        public Point _cord { get; init; }
        protected readonly string _name;
        protected string _species;
        protected int _steps;
        //protected double _age;
        //protected double _weight;
        //protected int _happines;

        public abstract void AnimalSound();
        public abstract void Draw();
        public abstract void Walk(int max_x, int max_y);
    }
}
