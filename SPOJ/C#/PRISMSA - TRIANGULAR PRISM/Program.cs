using System;

namespace PRISMSA___TRIANGULAR_PRISM
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                int volume = int.Parse(Console.ReadLine());
                double tmp = Math.Pow(4 * volume, (double)1 / 3);
                double surfaceArea = 3 * tmp * tmp * Math.Pow(3, 1 / (double)2) / 2;

                Console.WriteLine(surfaceArea);
            }
        }
    }
}
