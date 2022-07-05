using System;

namespace CPTTRN3
{
    class Program
    {
        static void Star() => Console.Write("*");
        static void StarLn() => Console.WriteLine("*");
        static void Dot() => Console.Write(".");
        static void Ln() => Console.WriteLine();

        static void Kratka(int wiersze, int kolumny)
        {
            for (int i = 0; i < wiersze; i++)
            {
                if (i == 0)
                    for (int k = 0; k < (3 * kolumny) + 1; k++)
                        Star();

                Ln();
                Star();

                for(int k = 0; k < kolumny; k++)
                {
                    Dot();
                    Dot();
                    Star();
                }

                Ln();
                Star();

                for (int k = 0; k < kolumny; k++)
                {
                    Dot();
                    Dot();
                    Star();
                }

                Ln();

                for (int k = 0; k < (3 * kolumny) + 1; k++)
                {
                    Star();
                }
            }
        }

        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());

            for(int i = 0; i < t; i++)
            {
                string[] wymiary = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int wiersze = int.Parse(wymiary[0]);
                int kolumny = int.Parse(wymiary[1]);

                Kratka(wiersze, kolumny);
                Console.WriteLine();
            }
        }
    }
}
