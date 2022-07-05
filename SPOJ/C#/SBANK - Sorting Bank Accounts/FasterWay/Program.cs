using System;
using System.Collections.Generic;
using System.Text;

namespace FasterWay
{
    class Program
    {
        static void Main()
        {
            int t = int.Parse(Console.ReadLine());
            StringBuilder wyjscie = new StringBuilder();

            for (int i = 0; i < t; i++)
            {
                SortedSet<string> lista = new SortedSet<string>();
                Dictionary<string, int> ilosc = new Dictionary<string, int>();
                int n = int.Parse(Console.ReadLine());

                for (int j = 0; j < n; j++)
                {
                    string acc = Console.ReadLine();

                    if (ilosc.TryGetValue(acc, out int result))
                    {
                        result++;
                        ilosc[acc] = result;
                    }
                    else
                    {
                        lista.Add(acc);
                        ilosc[acc] = 1;              
                    }
                }

                Console.ReadLine();

                foreach (string value in lista)
                {
                    wyjscie.AppendLine(value + " " + ilosc[value]);
                }

                wyjscie.Append("\n");
            }

            Console.Write(wyjscie);
        }
    }
}