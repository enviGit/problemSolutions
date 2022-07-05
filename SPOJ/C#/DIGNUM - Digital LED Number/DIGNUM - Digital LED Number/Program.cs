using System;

namespace DIGNUM___Digital_LED_Number
{
    class Program
    {
        static void Main(string[] args)
        {
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

            string _linia1;
            string _linia2;
            string _linia3;
            string cyfry = "";

            while ((_linia1 = Console.ReadLine()) != null)
            {
                char[] linia1 = _linia1.ToCharArray();

                _linia2 = Console.ReadLine();
                if (_linia2 == null) break;
                char[] linia2 = _linia2.ToCharArray();

                _linia3 = Console.ReadLine();
                if (_linia3 == null) break;
                char[] linia3 = _linia3.ToCharArray();

                int dlugosc = _linia1.Length;
                int ilosc = dlugosc / 3;

                for (int i = 0; i <= ilosc; ++i)
                {
                    if ((linia1.Length >= (2 + i * 3)) && (linia2.Length >= (2 + i * 3)) && (linia3.Length >= (2 + i * 3)))
                    {
                        int licznik = 0;

                        for (int j = 0; j < 3; j++)
                        {
                            if (linia1[j + i * 3] == zero[0, j] && linia2[j + i * 3] == zero[1, j] && linia3[j + i * 3] == zero[2, j])
                            {
                                licznik++;

                                if (licznik == 3)
                                    cyfry += 0;
                            }
                        }
                        licznik = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            if (linia1[j + i * 3] == jeden[0, j] && linia2[j + i * 3] == jeden[1, j] && linia3[j + i * 3] == jeden[2, j])
                            {
                                licznik++;

                                if (licznik == 3)
                                    cyfry += 1;
                            }
                        }
                        licznik = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            if (linia1[j + i * 3] == dwa[0, j] && linia2[j + i * 3] == dwa[1, j] && linia3[j + i * 3] == dwa[2, j])
                            {
                                licznik++;

                                if (licznik == 3)
                                    cyfry += 2;
                            }
                        }
                        licznik = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            if (linia1[j + i * 3] == trzy[0, j] && linia2[j + i * 3] == trzy[1, j] && linia3[j + i * 3] == trzy[2, j])
                            {
                                licznik++;

                                if (licznik == 3)
                                    cyfry += 3;
                            }
                        }
                        licznik = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            if (linia1[j + i * 3] == cztery[0, j] && linia2[j + i * 3] == cztery[1, j] && linia3[j + i * 3] == cztery[2, j])
                            {
                                licznik++;

                                if (licznik == 3)
                                    cyfry += 4;
                            }
                        }
                        licznik = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            if (linia1[j + i * 3] == piec[0, j] && linia2[j + i * 3] == piec[1, j] && linia3[j + i * 3] == piec[2, j])
                            {
                                licznik++;

                                if (licznik == 3)
                                    cyfry += 5;
                            }
                        }
                        licznik = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            if (linia1[j + i * 3] == szesc[0, j] && linia2[j + i * 3] == szesc[1, j] && linia3[j + i * 3] == szesc[2, j])
                            {
                                licznik++;

                                if (licznik == 3)
                                    cyfry += 6;
                            }
                        }
                        licznik = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            if (linia1[j + i * 3] == siedem[0, j] && linia2[j + i * 3] == siedem[1, j] && linia3[j + i * 3] == siedem[2, j])
                            {
                                licznik++;

                                if (licznik == 3)
                                    cyfry += 7;
                            }
                        }
                        licznik = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            if (linia1[j + i * 3] == osiem[0, j] && linia2[j + i * 3] == osiem[1, j] && linia3[j + i * 3] == osiem[2, j])
                            {
                                licznik++;

                                if (licznik == 3)
                                    cyfry += 8;
                            }
                        }
                        licznik = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            if (linia1[j + i * 3] == dziewiec[0, j] && linia2[j + i * 3] == dziewiec[1, j] && linia3[j + i * 3] == dziewiec[2, j])
                            {
                                licznik++;

                                if (licznik == 3)
                                    cyfry += 9;
                            }
                        }
                        licznik = 0;
                    }
                }

                cyfry += "\n";
            }

            Console.WriteLine(cyfry);
        }
    }
}
