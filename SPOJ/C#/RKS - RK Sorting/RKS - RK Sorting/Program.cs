using System;
using System.Collections.Generic;
using System.Linq;

namespace RKS___RK_Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] linia1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(linia1[0]);
            long c = long.Parse(linia1[1]);
            string[] linia2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<long> liczby = new List<long>(n);
            Dictionary<string, long> ilosc = new Dictionary<string, long>();

            foreach(string value in linia2)
            {
                if (liczby.Contains(long.Parse(value)))
                    ilosc[value]++;
                else
                    ilosc[value] = 1;

                liczby.Add(long.Parse(value));
            }

            var zmienna = ilosc.OrderByDescending(x => x.Value).Select(x => x.Key);

            foreach (var value in zmienna)
            {
                ilosc.TryGetValue(value, out long wartosc);

                for(int i = 0; i < wartosc; i++)
                    Console.Write(value + " ");
            }
        }
    }
}