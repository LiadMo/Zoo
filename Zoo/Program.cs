using System;
using System.Collections.Generic;
using System.Threading;


namespace Zoo
{
    internal class program
    {
        static void Main(string[] args)
        {
            var e1 = new Elephant("pil");
            int milliseconds = 500;
            List<IAnimal> animals = new List<IAnimal>();
            animals.Add(e1);

            Canvas frame = Canvas.CreateCanvas();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (frame != null)
            {
                frame.DrawCanvas();
                foreach (var animal in animals)
                {
                    animal.Draw();
                    animal.Walk();
                }

                Thread.Sleep(milliseconds);
                //Console.Read();
            }

        }
    }
}
