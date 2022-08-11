using System;

namespace Zoo
{
    internal class Zoo
    {
        static void Main(string[] args)
        {
            Canvas frame = Canvas.CreateCanvas();
         //   Canvas frame2 = Canvas.CreateCanvas();
         //   Console.WriteLine(frame.GetHashCode());
         //   Console.WriteLine(frame2.GetHashCode());

            while (frame != null)
            {
                frame.DrawCanvas();
                Console.Read();
            }

        }
    }
}
