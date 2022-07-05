using System;

namespace SMPSEQ9___Fun_with_Sequences
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
            float sredniaS = 0;
            float sredniaQ = 0;

            foreach (string value in S)
                sredniaS += int.Parse(value);

            sredniaS /= n;

            foreach (string value in Q)
                sredniaQ += int.Parse(value);

            sredniaQ /= m;

            if (sredniaQ < sredniaS)
                for (int i = 0; i < n; i++)
                    Console.Write(S[i] + " ");
            else
                for (int i = 0; i < m; i++)
                    Console.Write(Q[i] + " ");
        }
    }
}