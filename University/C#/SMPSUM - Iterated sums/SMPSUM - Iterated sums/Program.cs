using System;

namespace SMPSUM___Iterated_sums
{
    class Program
    {
        static void Main(string[] args)
        {
            string linia = Console.ReadLine();
            string[] tab = linia.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int a = int.Parse(tab[0]);
            int b = int.Parse(tab[1]);
            int suma = 0;

            for (int i = a; i <= b; i++)
                suma = suma + i * i;

            Console.Write(suma);
        }
    }
}
