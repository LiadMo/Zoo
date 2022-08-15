using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    interface IAnimal
    {
        void AnimalSound();
        void Walk(int max_x, int max_y);
        void Draw();
    }
}
