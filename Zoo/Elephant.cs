using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Zoo
{
    internal class Elephant : Animal {


        public Elephant(string name) {
            this._name = name;
            this._species = "Elephant";
            this._cord = new Point(0, 0);
            this._steps = 3;

        } // TODO

        public override void Draw() {
            Console.SetCursorPosition(this._cord._x, this._cord._y);
            Console.Write("E");
            
        } 

        public override void AnimalSound() {
            Console.WriteLine("Whohohohooh - Elephant sound");
        }
        public override void Walk(int max_x, int max_y) {
            var random = new Random();
            
            int x_to_add = random.Next(-_steps, _steps + 1);
            int y_to_add = random.Next(-_steps, _steps + 1);
            this._cord.UpdatePoint(x_to_add, y_to_add);
            if (!this._cord.IsValidPoint(max_x,max_y))
            {
                this._cord.UpdatePoint(-x_to_add, -y_to_add);
            }

        } // TODO
    }
}
