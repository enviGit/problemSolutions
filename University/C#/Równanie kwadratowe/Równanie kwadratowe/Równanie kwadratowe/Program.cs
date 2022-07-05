using System;

namespace Równanie_kwadratowe
{
    class Program
    {
        public static void QuadraticEquation(int a, int b, int c)
        {
            double delta = b * b - 4 * a * c;
            
            if (a == 0 && a == b && b == c) Console.WriteLine("infinity");
            else if (delta < 0 || (a == 0 && a == b)) Console.WriteLine("empty");
            else if (delta > 0 && a != 0)
            {
                double pierwiastek1 = Math.Round(Math.Min((-b - Math.Sqrt(delta)) / (2 * a), (-b + Math.Sqrt(delta)) / (2 * a)), 2);
                double pierwiastek2 = Math.Round(Math.Max((-b - Math.Sqrt(delta)) / (2 * a), (-b + Math.Sqrt(delta)) / (2 * a)), 2);

                Console.WriteLine($"x1={pierwiastek1:F2}");
                Console.WriteLine($"x2={pierwiastek2:F2}");
            }
            else if(delta == 0 || (delta > 0 && a == 0))
            {
                double pierwiastek = Math.Round((-b / ((double)2 * a)), 2);

                Console.WriteLine($"x={pierwiastek:F2}");
            }
        }
        static void Main(string[] args)
        {
            QuadraticEquation(0, 2, 1);
        }
    }
}
