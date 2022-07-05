using System;

namespace Liczby
{
    class Program
    {
        static void Main(string[] args)
        {
            int test = int.Parse(Console.ReadLine());

            for(int i = 0; i < test; i++)
            {
                int n = int.Parse(Console.ReadLine());
                string linia = Console.ReadLine();
                string[] tab = linia.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int suma = 0;

                for(int j = 0; j < n; j++)
                {
                    int x = int.Parse(tab[j]);
                    suma += x; 
                }

                Console.WriteLine(suma);
            }
        }
    }
}
