using System;

namespace Tablica_postrzępiona
{
    class Program
    {
        static char[][] ReadJaggedArrayFromStdInput()
        {
            int test = int.Parse(Console.ReadLine());
            char[][] tab;
            tab = new char[test][];

            for (int i = 0; i < test; i++)
            {
                string[] litery = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                char[] znaki = string.Join(string.Empty, litery).ToCharArray();
                tab[i] = new char[znaki.Length];

                for (int j = 0; j < znaki.Length; j++)
                    tab[i][j] = znaki[j];
            }

            return tab;
        }
        static void PrintJaggedArrayToStdOutput(char[][] tab)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                for (int j = 0; j < tab[i].Length; j++)
                {
                    Console.Write(tab[i][j] + " ");
                }

                Console.WriteLine();
            }
        }

        static char[][] TransposeJaggedArray(char[][] tab)
        {
            int wynik = 0;

            for (int i = 0; i < tab.Length; i++)
            {
                if (wynik < tab[i].Length)
                    wynik = tab[i].Length;
            }

            int maxDlugosc = wynik;
            char[][] transponowana = new char[maxDlugosc][];

            for (int i = 0; i < maxDlugosc; i++)
            {
                transponowana[i] = new char[tab.Length];

                for (int j = 0; j < tab.Length; j++)
                {
                    try
                    {
                        transponowana[i][j] = tab[j][i];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        transponowana[i][j] = ' ';
                    }
                }
            }

            return transponowana;
        }
        static void Main(string[] args)
        {
            char[][] jagged = ReadJaggedArrayFromStdInput();
            PrintJaggedArrayToStdOutput(jagged);
            jagged = TransposeJaggedArray(jagged);
            Console.WriteLine();
            PrintJaggedArrayToStdOutput(jagged);
        }
    }
}