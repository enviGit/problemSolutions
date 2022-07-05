using System;

namespace CPTTRN4
{
    class Program
    {
        static void Star() => Console.Write("*");
        static void Dot() => Console.Write(".");
        static void Ln() => Console.WriteLine();

        static void Kratka(int wiersze, int kolumny, int wysokosc, int szerokosc)
        {
            int licznik = 0;

            for (int i = 0; i < kolumny; i++)
            {
                for (int j = 0; j < szerokosc; j++)
                    licznik++;

                licznik++;
            }

            for (int i = 0; i < wiersze; i++)
            {
                if (i == 0)
                    for (int k = 0; k < licznik + 1; k++)
                        Star();

                for(int k = 0; k < wysokosc; k++)
                {
                    Ln();
                    Star();

                    for (int l = 0; l < kolumny; l++)
                    {
                        for(int m = 0; m < szerokosc; m++)
                            Dot();
                        
                        Star();
                    }
                }

                Ln();

                for (int k = 0; k < licznik + 1; k++)
                    Star();
            }
        }

        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                string[] wymiary = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int wiersze = int.Parse(wymiary[0]);
                int kolumny = int.Parse(wymiary[1]);
                int wysokosc = int.Parse(wymiary[2]);
                int szerokosc = int.Parse(wymiary[3]);

                Kratka(wiersze, kolumny, wysokosc, szerokosc);
                Console.WriteLine();
            }
        }
    }
}
