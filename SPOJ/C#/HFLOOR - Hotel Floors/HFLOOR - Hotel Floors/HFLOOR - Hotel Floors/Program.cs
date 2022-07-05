using System;

namespace HFLOOR___Hotel_Floors
{
    class Program
    {
        static void Main(string[] args)
        {
            int test = int.Parse(Console.ReadLine());
            int rooms = 0;
            int people = 0;
            double avg = 0;
            double[] avgCollection = new double[test];

            for (int i = 0; i < test; i++)
            {
                string[] matrix = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int m = int.Parse(matrix[0]);
                int n = int.Parse(matrix[1]);
                char[,] hotel = new char[m, n];

                for (int j = 0; j < hotel.GetLength(0); j++)
                {
                    for (int k = 0; k < hotel.GetLength(1); k++)
                    {
                        hotel[j, k] = Convert.ToChar(Console.Read());

                        if (hotel[j, k] == '*')
                            people++;
                    }

                    Console.ReadLine();
                }
                for (int j = 0; j < hotel.GetLength(0); j++)
                    for (int k = 0; k < hotel.GetLength(1); k++)
                        if (hotel[j, k] == '*')
                        {
                            rooms++;

                            if (hotel[j, k + 1] != '#')
                                rooms -= 1;
                        }

                avg = (double)people / (double)rooms;
                avgCollection[i] = avg;
                people = 0;
                rooms = 0;
                avg = 0;
            }

            for(int i = 0; i < avgCollection.Length; i++)
                Console.WriteLine($"{avgCollection[i]:F2}");
        }
    }
}
