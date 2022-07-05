using System;

namespace FCTRL3___Dwie_cyfry_silni
{
    class Program
    {
        static void Main(string[] args)
        {
            int test = int.Parse(Console.ReadLine());
            
            for(int i = 0; i < test; i++)
            {
                int linia = int.Parse(Console.ReadLine());
                int silnia = 1;
                int dziesiatki = 0;
                int jednosci = 0;

                if(linia == 0)
                {
                    Console.WriteLine(0 + "  " + 1);
                }
                else if (linia <= 9)
                { 
                    for (int j = 1; j <= linia; j++)
                    {
                        silnia = silnia * j;
                        dziesiatki = (silnia % 100) / 10;
                        jednosci = silnia % 10;
                    }
                    Console.WriteLine(dziesiatki + "  " + jednosci);
                }
                else
                    Console.WriteLine(0 + "  " + 0);
            }
        }
    }
}
