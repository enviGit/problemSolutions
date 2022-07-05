using System;

namespace Sortowanie_bąbelkowe___implementacja
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] linia = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] zakres = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int odkad = int.Parse(zakres[0]);
            int dokad = int.Parse(zakres[1]);
            int[] liczby = new int[dokad - odkad + 1];
            int licznik = 0;

            for (int i = odkad; i <= dokad; i++)
            {
                liczby[licznik] = int.Parse(linia[i]);
                licznik++;
            }
            for (int i = 0; i < odkad; i++)
            {
                Console.Write(int.Parse(linia[i]) + " ");
            }
            for (int i = 0; i < liczby.Length - 1; i++)
            {
                for (int j = 0; j < liczby.Length - i - 1; j++)
                {
                    if (liczby[j] < liczby[j + 1])
                    {
                        int tmp = liczby[j];
                        liczby[j] = liczby[j + 1];
                        liczby[j + 1] = tmp;
                    }
                }

            }
            for (int i = 0; i < liczby.Length; i++)
            {
                Console.Write(liczby[i] + " ");
            }
            for (int i = dokad + 1; i < linia.Length; i++)
            {
                Console.Write(int.Parse(linia[i]) + " ");
            }
        }
    }
}
