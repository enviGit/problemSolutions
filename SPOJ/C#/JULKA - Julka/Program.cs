using System;
using System.Numerics;

namespace JULKA___Julka
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger moreKlaudia;
            BigInteger lessNatalia;

            for(int i = 0; i < 10; i++)
            {
                BigInteger a = BigInteger.Parse(Console.ReadLine());
                BigInteger b = BigInteger.Parse(Console.ReadLine());

                lessNatalia = (a - b) / 2;
                moreKlaudia = lessNatalia + b;

                Console.WriteLine(moreKlaudia);
                Console.WriteLine(lessNatalia);
            }
        }
    }
}