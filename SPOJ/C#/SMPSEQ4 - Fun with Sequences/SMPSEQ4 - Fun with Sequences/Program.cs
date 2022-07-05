using System;
using System.Linq;

namespace SMPSEQ4___Fun_with_Sequences
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] tab1 = new string[s.Length];
            tab1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string q = Console.ReadLine();
            string[] tab2 = new string[q.Length];
            tab2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var zPowtorzeniami = tab1.Intersect(tab2);

            foreach (string value in zPowtorzeniami)
            {
                Console.Write(value + " ");
            }
        }
    }
}
