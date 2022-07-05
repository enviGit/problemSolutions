using System;

namespace CPTTRN1
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                string[] wymiary = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int wiersze = int.Parse(wymiary[0]);
                int kolumny = int.Parse(wymiary[1]);

                for (int j = 0; j < wiersze; j++)
                {
                    if (kolumny % 2 != 0)
                    {
                        for (int k = 0; k < kolumny / 2 + 1; k++)
                        {
                            if(k == kolumny / 2)
                            {
                                if (j % 2 == 0)
                                    Console.Write("*");
                                else
                                    Console.Write(".");
                            }
                            else
                            {
                                if (j % 2 == 0)
                                    Console.Write("*.");
                                else
                                    Console.Write(".*");
                            }
                        }
                    }
                    else
                    {
                        for (int k = 0; k < kolumny / 2; k++)
                        {
                            if (j % 2 == 0)
                                Console.Write("*.");
                            else
                                Console.Write(".*");
                        }
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }
    }
}
