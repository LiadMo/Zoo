namespace Zoo {
    class Point {
        #region public properties
        public int X { get; set; }
        public int Y { get; set; }
        #endregion

        #region constructor's
        /// <summary>
        /// constructor 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// default constructor (x = 0, y = 0)
        /// </summary>
        public Point() {
            this.X = 0;
            this.Y = 0;
        }
        #endregion

        #region methods
        /// <summary>
        /// update the x & y of the point
        /// </summary>
        /// <param name="delta_x">the amount of x to add</param>
        /// <param name="delta_y">the amount of y to add</param>
        public void UpdatePoint(int delta_x, int delta_y) {
            X += delta_x;
            Y += delta_y;
        }

        /// <summary>
        /// check if point is in the frame
        /// </summary>
        /// <param name="width">the width of the frame</param>
        /// <param name="height">the height of the frame</param>
        /// <returns></returns>
        public bool IsValidPoint(int width, int height) {
            return this.X <= width && this.X >= 0 && this.Y <= height && this.Y >= 0;
        }
        #endregion
    }
}
