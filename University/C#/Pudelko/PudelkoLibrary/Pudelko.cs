using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;

namespace PudelkoLib
{
    public static class _Pudelko
    {
        public static Pudelko Kompresuj(this Pudelko pudelko)
        {
            double rozmiar = Math.Cbrt(pudelko.Objetosc);

            return new Pudelko(rozmiar, rozmiar, rozmiar);
        }
    }
    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>, IEnumerable<double>, IComparable<Pudelko>
    {
        public double A
        {
            get => Convert.ToDouble(a.ToString("0.000"));
            set => a = value;
        }
        public double B
        {
            get => Convert.ToDouble(b.ToString("0.000"));
            set => b = value;
        }

        public double C
        {
            get => Convert.ToDouble(c.ToString("0.000"));
            set => c = value;
        }
        private double a, b, c;

        private UnitOfMeasure jednostka { get; set; }

        public double Objetosc { get => Math.Round((A * B * C), 9); }
        public double Pole { get => Math.Round(2 * (A * B + A * C + B * C), 6); }
        public Pudelko(double? a = null, double? b = null, double? c = null, UnitOfMeasure jednostka = UnitOfMeasure.meter)
        {
            A = (double)(a != null ? (Zaokraglij((double)a / (ushort)jednostka)) : 0.1);
            B = (double)(b != null ? (Zaokraglij((double)b / (ushort)jednostka)) : 0.1);
            C = (double)(c != null ? (Zaokraglij((double)c / (ushort)jednostka)) : 0.1);

            if (A <= 0 | A > 10 | B <= 0 | B > 10 | C <= 0 | C > 10)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.jednostka = jednostka;
        }

        private double Zaokraglij(double number)
        {
            return Math.Floor(number * Math.Pow(10, 3)) / Math.Pow(10, 3);
        }

        public override string ToString()
        {
            return ToString("m");
        }

        public string ToString(string format)
        {
            if (format == null) format = "m";

            return ToString(format, CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            ushort jednostka = (ushort)Pudelko.GetUnitForFormat(format);
            int cyfry = 3;

            if (format == "cm")
            {
                cyfry = 1;
            }
            else if (format == "mm")
            {
                cyfry = 0;
            }

            return $"{(A * jednostka).ToString("0." + new String('0', cyfry))} {format} \u00D7 {(B * jednostka).ToString("0." + new String('0', cyfry))} {format} \u00D7 {(C * jednostka).ToString("0." + new String('0', cyfry))} {format}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Pudelko)
            {
                return Equals((Pudelko)obj);
            }

            return base.Equals(obj);
        }
        public bool Equals(Pudelko pudelko)
        {
            return (Pole == pudelko.Pole && Objetosc == pudelko.Objetosc);
        }

        public override int GetHashCode()
        {
            return A.GetHashCode() + B.GetHashCode() + C.GetHashCode() + jednostka.GetHashCode();
        }
        public static bool operator ==(Pudelko pudelko1, Pudelko pudelko2) => pudelko1.Equals(pudelko2);
        public static bool operator !=(Pudelko pudelko1, Pudelko pudelko2) => !pudelko1.Equals(pudelko2);

        public static explicit operator double[](Pudelko pudelko) => new double[] { pudelko.A, pudelko.B, pudelko.C };

        public static implicit operator Pudelko(ValueTuple<double, double, double> pudelko) => new Pudelko(pudelko.Item1, pudelko.Item2, pudelko.Item3, UnitOfMeasure.milimeter);

        public static Pudelko operator +(Pudelko pudelko1, Pudelko pudelko2)
        {
            double[] p1 = (double[])pudelko1, p2 = (double[])pudelko2;
            Array.Sort(p1);
            Array.Sort(p2);

            return new Pudelko(p1[0] + p2[0], p1[1] + p2[1], p1[2] + p2[2]);
        }
        public double this[int x]
        {
            get
            {
                switch (x)
                {
                    case 0:
                        return A;
                    case 1:
                        return B;
                    case 2:
                        return C;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        public IEnumerator<double> GetEnumerator()
        {
            return new Enum(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static Pudelko Parse(string strinToParse)
        {
            Regex reg = new Regex(@"(?<a>\d+\.?\d*)\s(?<format>\w+).*?(?<b>\d+\.?\d*)\s\w+.*?(?<c>\d+\.?\d*)\s\w+");
            Match match = reg.Match(strinToParse);
            string format = match.Groups["format"].Value;

            return new Pudelko(double.Parse(match.Groups["a"].Value), double.Parse(match.Groups["b"].Value), double.Parse(match.Groups["c"].Value),
                Pudelko.GetUnitForFormat(format));
        }
        private static UnitOfMeasure GetUnitForFormat(string format)
        {
            if (format == "m")
            {
                return UnitOfMeasure.meter;
            }
            else if (format == "cm")
            {
                return UnitOfMeasure.centimeter;
            }
            else if (format == "mm")
            {
                return UnitOfMeasure.milimeter;
            }

            throw new FormatException();
        }

        public int CompareTo(Pudelko pudelko)
        {
            double objetoscP1 = Objetosc;
            double objetoscP2 = pudelko.Objetosc;

            if (objetoscP1 == objetoscP2)
            {
                double poleP1 = Pole;
                double poleP2 = pudelko.Pole;

                if (poleP1 == poleP2)
                {
                    double sumaP1 = A + B + C;
                    double sumaP2 = pudelko.A + pudelko.B + pudelko.C;

                    if (sumaP1 == sumaP2) return 0;

                    return sumaP1 < sumaP2 ? 1 : -1;
                }
                return poleP1 < poleP2 ? 1 : -1;
            }
            return (objetoscP1 < objetoscP2) ? 1 : -1;
        }
    }
}