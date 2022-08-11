using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Canvas
    {
        private int Width;
        private int Height;
        private static Canvas instance = null; // hold the instance

        // private c'tor (Singelton)
        private Canvas(int width, int height)
        {
            Width = width;
            Height = height;
        }
        
        // call the c'tor only is the first instance
        public Canvas CreateCanvas(int width = 600, int height = 200)
        {
            if (instance == null)
                instance = new Canvas(width, height);
            return instance;
        }

        public void DrawCanvas()
        {
            Console.Clear();
            // toDO
        }
    }
}
