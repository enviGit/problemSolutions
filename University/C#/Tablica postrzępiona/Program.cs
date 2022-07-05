using System;

namespace transponowanie_tablic
{
    class Program
    {
        static char[][] ReadJaggedArrayFromStdInput()
        {
            int n = Int32.Parse(Console.ReadLine());
            char[][] result = new char[n][];
            for (int i=0; i<n; i++) {
                result[i] = Array.ConvertAll(Console.ReadLine().Split(" "), (c) => c[0]);
            }
            return result;
        }

        static void PrintJaggedArrayToStdOutput(char[][] array)
        {
            Array.ForEach(array, (column) => {
                Array.ForEach(column, (row) => Console.Write(row + " "));
                Console.WriteLine();
            });
        }

        static char[][] TransposeJaggedArray(char[][] array)
        {
            int maxLength = GetMaxLength(array);
            char[][] result = new char[maxLength][];
            for (int i=0; i<maxLength; i++) {
                result[i] = new char[array.Length];
                for (int j=0; j<array.Length; j++) {
                    try {
                        result[i][j] = array[j][i];
                    } catch (IndexOutOfRangeException) {
                        result[i][j] = ' ';
                    }
                }
            }
            return result;
        }

        static int GetMaxLength(char[][] array)
        {
            int result = 0;
            for (int i=0; i<array.Length; i++) {
                if (result < array[i].Length) result = array[i].Length;
            }
            return result;
        }

        static void Main(string[] args)
        {
            char[][] array = ReadJaggedArrayFromStdInput();
            PrintJaggedArrayToStdOutput(array);
            array = TransposeJaggedArray(array);
            PrintJaggedArrayToStdOutput(array);
        }
    }
}
