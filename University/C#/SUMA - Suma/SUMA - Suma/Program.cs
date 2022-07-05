using System;

namespace SUMA___Suma
{
    class Program
    {
        static void Main(string[] args)
        {
            int suma = 0;

            while (true)
            {
                string x = Console.ReadLine();

                if (String.IsNullOrEmpty(x)) break;

                int y = int.Parse(x);

                suma += y;

                Console.WriteLine(suma);
            }
        }
    }
}
