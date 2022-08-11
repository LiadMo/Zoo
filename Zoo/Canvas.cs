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
        public static Canvas CreateCanvas(int width = 40, int height = 20)
        {
            if (instance == null)
                instance = new Canvas(width, height);
            return instance;
        }

        public void DrawCanvas()
        {
            //Console.Clear();
            for (int i = 0; i < Width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write('-');
            }

            for (int i = 0; i < Width; i++)
            {
                Console.SetCursorPosition(i, Height);
                Console.Write('-');
            }

            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(0,i);
                Console.Write('-');
            }

            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(Width, i);
                Console.Write('-');
            }
        }
    }
}
