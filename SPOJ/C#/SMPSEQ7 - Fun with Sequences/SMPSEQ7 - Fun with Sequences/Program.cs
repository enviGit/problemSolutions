using System;

namespace SMPSEQ7___Fun_with_Sequences
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] tab = new string[n];
            tab = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            bool mozliwosc = true;
            int licznik = 1;

            for (int i = 1; i < n; i++)
            {
                if (int.Parse(tab[i]) >= int.Parse(tab[i - 1])) break;

                licznik++;
            }

            licznik++;

            for(int i = licznik; licznik < n; i++)
            {
                if (int.Parse(tab[licznik]) <= int.Parse(tab[licznik - 1]))
                {
                    mozliwosc = false;

                    break;
                }

                licznik++;
            }

            Console.WriteLine(mozliwosc == true ? "Yes" : "No");

            //bool decreasing = true;
            //bool increasing = true;

            /*for (int i = 1; i < n; i++)
            {
                if(int.Parse(tab[i]) < int.Parse(tab[i - 1]) && !decreasing)
                {
                    increasing = false;
                }
		        else if(int.Parse(tab[i]) == int.Parse(tab[i - 1]))
                {
                    if(decreasing)
                    {
                        decreasing = !decreasing;
                    }else
                    {
                        increasing = false;
                    }
                }
		        else if(int.Parse(tab[i]) > int.Parse(tab[i - 1]) && decreasing)
                {
                    decreasing = !decreasing;
                }
            }

            if (n == 2 || n == 3) Console.Write("Yes");
            else
                Console.WriteLine(increasing == true && decreasing == false ? "Yes" : "No");*/
        }
    }
}
