using System;

namespace LED_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string cyfry = Console.ReadLine();
            char[,] output = new char[3, cyfry.Length * 3];
            char[,] zero = {
                {' ', '_', ' '},
                {'|', ' ', '|'},
                {'|', '_', '|'}
            };
            char[,] jeden = {
                {' ', ' ', ' '},
                {' ', ' ', '|'},
                {' ', ' ', '|'}
            };
            char[,] dwa = {
                {' ', '_', ' '},
                {' ', '_', '|'},
                {'|', '_', ' '}
            };
            char[,] trzy = {
                {' ', '_', ' '},
                {' ', '_', '|'},
                {' ', '_', '|'}
            };
            char[,] cztery = {
                {' ', ' ', ' '},
                {'|', '_', '|'},
                {' ', ' ', '|'}
            };
            char[,] piec = {
                {' ', '_', ' '},
                {'|', '_', ' '},
                {' ', '_', '|'}
            };
            char[,] szesc = {
                {' ', '_', ' '},
                {'|', '_', ' '},
                {'|', '_', '|'}
            };
            char[,] siedem = {
                {' ', '_', ' '},
                {' ', ' ', '|'},
                {' ', ' ', '|'}
            };
            char[,] osiem = {
                {' ', '_', ' '},
                {'|', '_', '|'},
                {'|', '_', '|'}
            };
            char[,] dziewiec = {
                {' ', '_', ' '},
                {'|', '_', '|'},
                {' ', ' ', '|'}
            };

            for(int i = 0; i < cyfry.Length; i++)
            {
                switch(cyfry[i])
                {
                    case '0':
                        for(int j = 0; j < 3; j++)
                        {
                            for(int k = 0; k < 3; k++)
                            {
                                output[j, k + 3 * i] = zero[j, k];
                            }
                        }
                        break;
                    case '1':
                        for (int j = 0; j < 3; j++)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                output[j, k + 3 * i] = jeden[j, k];
                            }
                        }
                        break;
                    case '2':
                        for (int j = 0; j < 3; j++)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                output[j, k + 3 * i] = dwa[j, k];
                            }
                        }
                        break;
                    case '3':
                        for (int j = 0; j < 3; j++)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                output[j, k + 3 * i] = trzy[j, k];
                            }
                        }
                        break;
                    case '4':
                        for (int j = 0; j < 3; j++)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                output[j, k + 3 * i] = cztery[j, k];
                            }
                        }
                        break;
                    case '5':
                        for (int j = 0; j < 3; j++)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                output[j, k + 3 * i] = piec[j, k];
                            }
                        }
                        break;
                    case '6':
                        for (int j = 0; j < 3; j++)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                output[j, k + 3 * i] = szesc[j, k];
                            }
                        }
                        break;
                    case '7':
                        for (int j = 0; j < 3; j++)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                output[j, k + 3 * i] = siedem[j, k];
                            }
                        }
                        break;
                    case '8':
                        for (int j = 0; j < 3; j++)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                output[j, k + 3 * i] = osiem[j, k];
                            }
                        }
                        break;
                    case '9':
                        for (int j = 0; j < 3; j++)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                output[j, k + 3 * i] = dziewiec[j, k];
                            }
                        }
                        break;
                }
            }

            for(int i = 0; i < output.GetLength(0); i++)
            {
                for(int j = 0; j < output.GetLength(1); j++)
                {
                    Console.Write(output[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
