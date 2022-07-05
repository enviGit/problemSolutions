using System;

namespace KM001Z001___Wzorki_1
{
    class Program
    {
        const char gwiazda = '*';
        const char kropka = '.';
        static void Star() => Console.Write(gwiazda);
        static void StarLn() => Console.WriteLine(gwiazda);
        static void Dot() => Console.Write(kropka);
        static void NewLine() => Console.WriteLine();

        public static void Main(string[] args)
        {
            string linia = Console.ReadLine();
            string[] tablica = linia.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int n = 0;
            int m = 0;

            if (tablica.Length == 2)
                n = int.Parse(tablica[1]);
            else if (tablica.Length == 3)
            {
                n = int.Parse(tablica[1]);
                m = int.Parse(tablica[2]);
            }
            else
                throw new ArgumentException("Za mała ilość argumentów! Format: {AB} {n} {m}");

            if (tablica[0] == "A")
            {
                if (n < 3 || m < 3)
                    throw new ArgumentException("Zbyt maly rozmiar! n, m >= 3");
                else if (n % 2 == 0)
                    n++;
                if (m % 2 == 0)
                    m++;

                for (int i = 0; i < n; i++)
                    Star();

                NewLine();

                for (int i = 1; i < m / 2; i++)
                {
                    Star();

                    for (int j = 1; j < n / 2; j++)
                        Dot();

                    Star();

                    for (int k = n / 2 + 1; k < n - 1; k++)
                        Dot();

                    StarLn();
                }

                for (int i = 0; i < n; i++)
                    Star();

                NewLine();

                for (int i = m / 2 + 1; i < m - 1; i++)
                {
                    Star();

                    for (int j = 1; j < n / 2; j++)
                        Dot();

                    Star();

                    for (int k = n / 2 + 1; k < n - 1; k++)
                        Dot();

                    StarLn();
                }

                for (int i = 0; i < n; i++)
                    Star();
            }
            else if (tablica[0] == "B")
            {
                if (n < 3)
                    throw new ArgumentException("Zbyt maly rozmiar! n >= 3");

                for (int i = 0; i < n; i++)
                    Star();

                NewLine();

                for (int i = 1; i < n - 1; i++)
                {

                    for (int j = 0; j < i; j++)
                    {
                        Dot();
                    }

                    Star();

                    for (int k = i; k < n - 1; k++)
                        Dot();

                    NewLine();
                }

                for (int i = 0; i < n; i++)
                    Star();
            }
            else
                throw new ArgumentException("Niepoprawny argument, wpisz A lub B");
        }
    }
}
