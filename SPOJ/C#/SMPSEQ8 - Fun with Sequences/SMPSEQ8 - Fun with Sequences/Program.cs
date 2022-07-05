using System;

namespace SMPSEQ8___Fun_with_Sequences
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] S = new string[n];
            S = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int m = int.Parse(Console.ReadLine());
            string[] Q = new string[m];
            Q = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int sumaS = 0;
            int sumaQ = 0;

            foreach (string value in S)
                sumaS += int.Parse(value);
            foreach (string value in Q)
                sumaQ += int.Parse(value);

            if (sumaQ < sumaS)
                for (int i = 0; i < n; i++)
                    Console.Write(S[i] + " ");
            else
                for (int i = 0; i < m; i++)
                    Console.Write(Q[i] + " ");
        }
    }
}
