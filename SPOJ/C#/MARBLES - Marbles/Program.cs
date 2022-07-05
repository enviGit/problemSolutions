using System;
using System.Numerics;

public class Test
{
    public static void Main()
    {
        int t = int.Parse(Console.ReadLine());

        for(int i = 0; i < t; i++)
        {
            int[] linia = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            int n = linia[0] - 1;
            int k = linia[1] - 1;

            k = Math.Min(k, n - k);

            if(k == 0)
                Console.WriteLine(1);
            else
            {
                BigInteger result = n;

                for (int j = 2; j <= k; ++j)
                {
                    result *= n - j + 1;
                    result /= j;
                }

                Console.WriteLine(result);
            }
        }
    }
}