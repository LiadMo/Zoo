using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Zoo {
        List<IAnimal> animals;
        Canvas canvas;

        public Zoo(int width = 110, int height = 25) { 
            animals = new List<IAnimal>();
            canvas = Canvas.CreateCanvas(width, height);
        }
    }
}
