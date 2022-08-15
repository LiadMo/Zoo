using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    internal class Canvas
    {
        public int _width { get; set; }
        public int _height { get; set; }
        private static Canvas _instance = null;


        private Canvas(int width, int height) {
            _width = width;
            _height = height;
        }
        public static Canvas CreateCanvas(int width = 110, int height = 25) {
            if (_instance == null)
                _instance = new Canvas(width, height);
            return _instance;
        }


        public void DrawCanvas() {
            Console.Clear();
            for (int i = 0; i < _width; i++) {
                Console.SetCursorPosition(i, 0);
                Console.Write('-');
            }
            for (int i = 0; i < _width; i++) {
                Console.SetCursorPosition(i, _height);
                Console.Write('-');
            }
            for (int i = 0; i < _height; i++) {
                Console.SetCursorPosition(0,i);
                Console.Write('-');
            }
            for (int i = 0; i < _height; i++) {
                Console.SetCursorPosition(_width, i);
                Console.Write('-');
            }
        } // print the frame
    }
}
