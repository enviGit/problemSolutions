using System;

namespace TEST__ad_hoc_1
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                int n = int.Parse(Console.ReadLine());

                if (n == 42) break;

                Console.WriteLine(n);
            }
        }
    }
}
