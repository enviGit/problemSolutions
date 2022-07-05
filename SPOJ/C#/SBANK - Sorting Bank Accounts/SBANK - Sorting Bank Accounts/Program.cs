using System;
using System.Collections.Generic;
using System.Linq;

namespace SBANK___Sorting_Bank_Accounts
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            var dictionary = "";

            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(Console.ReadLine());
                Dictionary<string, int> lista = new Dictionary<string, int>();

                for (int j = 0; j < n; j++)
                {
                    string acc = Console.ReadLine();

                    if (lista.ContainsKey(acc))
                    {
                        lista.TryGetValue(acc, out int result);
                        result++;
                        lista[acc] = result;
                    }
                    else
                    {
                        lista.Add(acc, 1);
                    }
                }

                Console.ReadLine();

                foreach (KeyValuePair<string, int> value in lista.OrderBy(key => key.Key))
                    dictionary += value.Key + " " + value.Value + "\n";

                lista.Clear();

                dictionary += "\n";
            }

            Console.Write(dictionary);
        }
    }
}
