using System;
using System.Collections.Generic;
using System.Linq;
using PudelkoLib;

namespace PudelkoApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var lista = new List<Pudelko>
            {
                new Pudelko(0.2002, null, 0.10),
                new Pudelko(2.5, 9.321, 0.1, UnitOfMeasure.meter),
                new Pudelko(868.2, 374.21, 85.75, UnitOfMeasure.centimeter),
                new Pudelko(null, 25, null, UnitOfMeasure.milimeter),
                new Pudelko(270, 252, null, UnitOfMeasure.centimeter),
                new Pudelko(840.2, 590, 900, UnitOfMeasure.milimeter).Kompresuj(),
            };

            foreach(var n in lista)
                Console.WriteLine(n.ToString());

            Console.WriteLine("\n");
            var posortowane = lista.OrderBy(n => n.Objetosc).ThenBy(n => n.Pole).ThenBy(n => n.A + n.B + n.C).ToList();

            foreach (var pudelko in posortowane) Console.WriteLine(pudelko.ToString());

            Console.WriteLine("\n");
            Console.WriteLine((new Pudelko(2.5, 9.321, 0.1)).ToString());
            Console.WriteLine((new Pudelko(2.5, 9.321, 0.1)).ToString("mm"));
            Console.WriteLine((new Pudelko(2.5, 9.321, 0.1)).ToString("cm"));
            Console.WriteLine((new Pudelko(2.5, 9.321, 0.1)).ToString("m"));
            
            Console.WriteLine("\n\n2.5, 9.321, 0.1");
            Console.WriteLine((new Pudelko(2.5, 9.321, 0.1)).Objetosc);
            Console.WriteLine((new Pudelko(2.5, 9.321, 0.1)).Pole);

            Console.WriteLine("\n");
            var p1 = new Pudelko(2.5, 9.321, 0.1);
            var p2 = new Pudelko(2.5, 9.321, 0.1);
            var p3 = new Pudelko(2.5, 9.21, 0.1);
            Console.WriteLine(p1.Equals(p2));
            Console.WriteLine(p1.Equals(p3));

            Console.WriteLine("\n");
            Console.WriteLine(p1.GetHashCode());
            Console.WriteLine(p3.GetHashCode());

            Console.WriteLine("\n");
            Console.WriteLine(p1.CompareTo(p1));
            Console.WriteLine(p1.CompareTo(p3));

        }
    }
}

