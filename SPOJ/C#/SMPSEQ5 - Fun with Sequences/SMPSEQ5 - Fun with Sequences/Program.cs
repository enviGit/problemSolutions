using System;

namespace SMPSEQ5___Fun_with_Sequences
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            string[] tab1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Console.ReadLine();
            string[] tab2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < tab1.Length; i++)
            {
                if (i == tab2.Length) break;
                if (tab1[i] == tab2[i])
                {
                    int index = i + 1;

                    Console.Write(index + " ");
                }
            }

            /*int licznik1 = 0;
            int licznik2 = 0;

            for(int i = 0; i < tab1.Length; i++)
            {
                if (tab1[i] == tab2[i]) licznik1++;
            }
            for (int i = 0; i < tab1.Length; i++)
            {
                if (tab1[i] == tab2[i])
                {
                    if (i == tab2.Length) break;
                    if (licznik1 - 1 != licznik2)
                    {
                        Console.Write((i + 1) + " ");
                        licznik2++;
                    }
                    else
                    {
                        Console.Write(i + 1);
                        break;
                    }
                }
            }*/


        }
    }
}
