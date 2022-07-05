using System;
using System.Collections.Generic;
using System.Linq;

namespace MINSTACK___Smallest_on_the_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> stos = new List<int>();

            for(int i = 0; i < n; i++)
            {
                string[] linia = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch(linia[0])
                {
                    case "PUSH":
                        stos.Add(int.Parse(linia[1]));

                        break;
                    case "MIN":
                        if (stos.Count > 0)
                        {
                            int min = stos.Min(x => x);
                            Console.WriteLine(min);
                        }
                        else
                            Console.WriteLine("EMPTY");

                        break;
                    case "POP":
                        if (stos.Count > 0)
                            stos.RemoveAt(stos.Count - 1);
                        else
                            Console.WriteLine("EMPTY");

                        break;
                }
            }
        }
    }
}
