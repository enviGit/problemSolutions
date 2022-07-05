using System;
using System.Collections.Generic;

namespace Agregator_logów
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedDictionary<string, string> adres = new SortedDictionary<string, string>();
            SortedDictionary<string, int> lista = new SortedDictionary<string, int>();
            List<int> liczebnosc = new List<int>();
            int _i = 0;

            for (int i = 0; i < n; i++)
            {
                string[] tablica = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (!adres.ContainsKey(tablica[0])) 
                    adres.Add(tablica[0], tablica[1]);
                if (!lista.ContainsKey(tablica[1])) 
                    lista.Add(tablica[1], int.Parse(tablica[2]));
                else 
                    lista[tablica[1]] += int.Parse(tablica[2]);
            }
            foreach (var zmienna in lista)
            {
                int licznik = 0;

                foreach (var _zmienna in adres)
                {
                    if (zmienna.Key == _zmienna.Value)
                        licznik++;
                }

                liczebnosc.Add(licznik);
            }
            foreach (var zmienna in lista)
            {
                int j = 0;

                Console.Write(zmienna.Key + ": " + zmienna.Value + " [");

                foreach (var _zmienna in adres)
                {
                    
                    if (zmienna.Key == _zmienna.Value)
                    {
                        if (j < liczebnosc[_i] - 1) Console.Write(_zmienna.Key + ", ");
                        else Console.Write(_zmienna.Key);

                        j++;
                    }
                }

                Console.WriteLine("]");

                _i++;
            }
        }
    }
}