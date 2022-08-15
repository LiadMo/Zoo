using System;

namespace Zoo {
    internal class Canvas {
        #region properties
        public int Width { get; set; }
        public int Height { get; set; }
        private static Canvas _instance = null;
        #endregion

        private Canvas(int width, int height) {
            Width = width;
            Height = height;
        }

        public static Canvas CreateCanvas(int width = 110, int height = 25) {
            if (_instance == null) {
                _instance = new Canvas(width, height);
            }
            return _instance;
        }

        /// <summary>
        /// print the frame
        /// </summary>
        public void DrawCanvas() {
            Console.Clear();
            for (int i = 0; i < Width; i++) {
                Console.SetCursorPosition(i, 0);
                Console.Write('-');
            }
            for (int i = 0; i < Width; i++) {
                Console.SetCursorPosition(i, Height);
                Console.Write('-');
            }
            for (int i = 0; i < Height; i++) {
                Console.SetCursorPosition(0, i);
                Console.Write('-');
            }
            for (int i = 0; i < Height; i++) {
                Console.SetCursorPosition(Width, i);
                Console.Write('-');
            }
        }
    }
}
