using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    abstract class Animal : IAnimal {
        protected Point _cord;
        protected string _name;
        protected string _species;
        protected int _steps;
        //protected double _age;
        //protected double _weight;
        //protected int _happines;

        public abstract void AnimalSound();
        public abstract void Draw();
        public abstract void Walk();

    }
}
