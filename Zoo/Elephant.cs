using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Zoo
{
    internal class Elephant : Animal {


        public Elephant(String name) {
            this._name = name;
            this._species = "Elephant";
            this._cord = new Point(0, 0);
            this._steps = 1;

        } // TODO

        public override void Draw() {
            Console.SetCursorPosition(this._cord._x, this._cord._y);
            Console.Write("E");
        } 

        public override void AnimalSound() {
            Console.WriteLine("Whohohohooh - Elephant sound");
        }
        public override void Walk() {
            this._cord.UpdatePoint(1, 1);
        } // TODO
    }
}
