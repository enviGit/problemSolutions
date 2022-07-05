using System;

namespace Zadanie4
{
    class Program
    {
        static void Main()
        {
            var copier = new Copier();
            var printer = (IPrinter)copier;
            var scanner = (IScanner)copier;

            copier._StandbyOn();
            Console.WriteLine("Printer state: " + printer.GetState() + "\t\tScanner state: " + scanner.GetState());
            IDocument doc1 = new PDFDocument("aaa.pdf");
            copier.Print(doc1);
            Console.WriteLine("Printer state: " + printer.GetState() + "\t\tScanner state: " + scanner.GetState());
            copier.Print(doc1);
            copier.Print(doc1);
            copier.Print(doc1);
            IDocument doc2;
            copier.Scan(out doc2);
            Console.WriteLine("Printer state: " + printer.GetState() + "\t\tScanner state: " + scanner.GetState());
            copier.Scan(out doc2);
            copier.ScanAndPrint();

            Console.WriteLine("Print Counter:\t" + copier.PrintCounter);
            Console.WriteLine("Scan Counter:\t" + copier.ScanCounter);
            copier._StandbyOn();
            Console.WriteLine("Printer state: " + printer.GetState() + "\t\tScanner state: " + scanner.GetState());
        }
    }
}