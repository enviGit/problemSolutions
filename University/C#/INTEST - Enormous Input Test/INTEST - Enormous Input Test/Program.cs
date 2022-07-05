using System;

namespace INTEST___Enormous_Input_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] linia = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int licznik = 0;
            int n = int.Parse(linia[0]);
            int k = int.Parse(linia[1]);

            for (int i = 0; i < n; i++)
            {
                long t = long.Parse(Console.ReadLine());

                if (t % k == 0) licznik++;
            }

            Console.WriteLine(licznik);
        }
    }
}
