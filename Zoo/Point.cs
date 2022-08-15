using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    class Point {
        #region public properties
        public int _x { get; set; }
        public int _y { get; set; }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x, int y) {
            this._x = x;
            this._y = y;
        }
        public Point() {
            this._x = 0;
            this._y = 0;
        }
        public void UpdatePoint(int delta_x, int delta_y) {
            this._x += delta_x;
            this._y += delta_y;
        }

        public bool IsValidPoint(int width, int height)
        {
            return this._x <= width && this._x >= 0 && this._y <= height && this._y >= 0;
        }
    }
}
