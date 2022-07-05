using System;

namespace SMPSEQ6___Fun_with_Sequences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(values[0]);
            int x = int.Parse(values[1]);
            string[] tab1 = new string[n];
            string[] tab2 = new string[n];
            tab1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            tab2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < n; i++)
                for (int j = Math.Max(1, i - x); j <= Math.Min(n - 1, i + x); j++)
                    if (tab1[i] == tab2[j])
                        Console.Write((i + 1) + " ");
        }
    }
}
