using System;

namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            var xerox = new Copier();
            xerox.PowerOn();
            IDocument doc1 = new PDFDocument("aaa.pdf");
            xerox.Print(doc1);

            IDocument doc2;
            xerox.Scan(out doc2);
            xerox.ScanAndPrint();

            xerox.PowerOff();
            Console.WriteLine("\n");
            xerox.PowerOn();
            Console.WriteLine("PowerOn Counter:\t" + xerox.Counter);
            Console.WriteLine("Print Counter:\t\t" + xerox.PrintCounter);
            Console.WriteLine("Scan Counter:\t\t" + xerox.ScanCounter + "\n\n\n");



            var mD = new MultidimensionalDevice();
            mD.PowerOn();

            mD.Print(doc1);
            mD.Scan(out doc2);
            mD.ScanAndPrint();
            mD.SendFax(doc1, "Receiver");

            mD.PowerOff();
            Console.WriteLine("\n");
            mD.PowerOn();
            Console.WriteLine("PowerOn Counter:\t" + mD.Counter);
            Console.WriteLine("Print Counter:\t\t" + mD.PrintCounter);
            Console.WriteLine("Scan Counter:\t\t" + mD.ScanCounter);
            Console.WriteLine("Fax Counter:\t\t" + mD.FaxCounter);
        }
    }
}