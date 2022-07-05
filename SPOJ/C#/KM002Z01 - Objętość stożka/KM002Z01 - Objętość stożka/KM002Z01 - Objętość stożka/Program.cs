using System;

namespace KM002Z01___Objętość_stożka
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stdin = new string[2];
            stdin = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int r = int.Parse(stdin[0]);
            int l = int.Parse(stdin[1]);
            double pi = Math.PI;
            double rPow = Math.Pow(r, 2);
            double hPow = Math.Pow(l, 2) - Math.Pow(r, 2);
            double h = Math.Sqrt(hPow);
            double objetosc = 0;
            int a = 0;
            int b = 0;

            if (r < 0 || l < 0) Console.WriteLine("ujemny argument");
            else if (l < r || r + h < l) Console.WriteLine("obiekt nie istnieje");
            else
            {
                objetosc = (pi * rPow * h) / 3;

                double aTmp = Math.Floor(objetosc);
                double bTmp = Math.Ceiling(objetosc);
                a += Convert.ToInt32(aTmp);
                b += Convert.ToInt32(bTmp);

                Console.WriteLine(a + " " + b);
            }
        }
    }
}
