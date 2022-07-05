using System;
using System.Collections.Generic;

namespace TWOSQRS
{
    class Program
    {
        public static void Main(string[] args)
        {
            int test = int.Parse(Console.ReadLine());

            for (int i = 0; i < test; i++)
            {
                long n = long.Parse(Console.ReadLine());
                Dictionary<long, long> lista = new Dictionary<long, long>();
                bool sprawdz = false;

                for (long j = 0; j * j <= n; j++)
                {
                    lista.Add(j * j, 1);

                    if (lista.ContainsKey(n - j * j))
                        sprawdz = true;
                }
                
                if (sprawdz == true)
                    Console.WriteLine("Yes");
                else
                    Console.WriteLine("No");
            }
        }
    }
}
