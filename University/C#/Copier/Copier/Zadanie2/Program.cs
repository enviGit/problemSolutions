using System;

namespace Zadanie2
{
    class Program
    {
        static void Main()
        {
            var xerox = new MultifunctionalDevice();
            xerox.PowerOn();
            IDocument doc1 = new PDFDocument("aaa.pdf");
            xerox.Print(in doc1);

            IDocument doc2;
            xerox.Scan(out doc2);
            xerox.ScanAndPrint();
            xerox.ScanAndFax("Receiver");

            Console.WriteLine("\nPowerOn Counter:\t" + xerox.Counter);
            Console.WriteLine("Print Counter:\t\t" + xerox.PrintCounter);
            Console.WriteLine("Scan Counter:\t\t" + xerox.ScanCounter);
            Console.WriteLine("Fax Counter:\t\t" + xerox.FaxCounter);
        }
    }
}
