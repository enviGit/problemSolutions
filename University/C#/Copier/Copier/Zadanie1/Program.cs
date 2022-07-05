using System;

namespace Zadanie1
{
    class Program
    {
        static void Main()
        {
            var xerox = new Copier();
            xerox.PowerOn();

            IDocument doc1 = new PDFDocument("aaa.pdf");
            xerox.Print(in doc1);

            IDocument doc2;
            xerox.Scan(out doc2);
            xerox.ScanAndPrint();

            Console.WriteLine("\nPowerOn Counter:\t" + xerox.Counter);
            Console.WriteLine("Print Counter:\t\t" + xerox.PrintCounter);
            Console.WriteLine("Scan Counter:\t\t" + xerox.ScanCounter);
        }
    }
}