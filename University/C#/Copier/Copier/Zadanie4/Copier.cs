using System;

namespace Zadanie4
{
    public class Copier : IPrinter, IScanner
    {
        public int PrintCounter { get; set; }
        public int PrintsInRowCounter { get; set; }
        public int ScanCounter { get; set; }
        public int ScansInRowCounter { get; set; }
        public int Counter { get; set; }
        private IPrinter Printer;
        private IDevice.State PrinterState;
        private IScanner Scanner;
        private IDevice.State ScannerState;

        public Copier()
        {
            Printer = this;
            Scanner = this;
        }
        public IDevice.State GetState()
        {
            return IDevice.State.on;
        }
        void IPrinter.SetState(IDevice.State state)
        {
            PrinterState = state;
        }
        void IScanner.SetState(IDevice.State state)
        {
            ScannerState = state;
        }
        void IDevice.SetState(IDevice.State state)
        {
            Printer.SetState(state);
            Scanner.SetState(state);
        }
        IDevice.State IPrinter.GetState()
        {
            return PrinterState;
        }
        IDevice.State IScanner.GetState()
        {
            return ScannerState;
        }
        public void _PowerOn()
        {
            if (GetState() == IDevice.State.off)
            {
                Counter++;

                ((IDevice)this).PowerOn();
            }
        }
        public void _PowerOff()
        {
            if (GetState() != IDevice.State.off)
            {
                ((IDevice)this).PowerOff();
            }
        }
        public void _StandbyOn()
        {
            if (GetState() != IDevice.State.standby)
            {
                ((IDevice)this).StandbyOn();
            }
        }
        public void _StandbyOff()
        {
            if (GetState() == IDevice.State.standby)
            {
                ((IDevice)this).StandbyOff();
            }
        }
        public void Print(in IDocument document)
        {
            if (GetState() != IDevice.State.off)
            {
                if (Scanner.GetState() == IDevice.State.on) Scanner.StandbyOn();
                if (Printer.GetState() != IDevice.State.on)
                {
                    Printer.StandbyOff();
                }
                else if (PrintsInRowCounter == 3)
                {
                    Printer.StandbyOn();

                    PrintsInRowCounter = 0;

                    Console.WriteLine("\nPrinter in standby mode, please wait ...\n");

                    Printer.StandbyOff();
                }

                PrintsInRowCounter++;
                PrintCounter++;

                Console.WriteLine(DateTime.Now + " Print: " + document.GetFileName());
            }
        }
        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            document = null;

            if (GetState() != IDevice.State.off)
            {
                if (Printer.GetState() == IDevice.State.on) Printer.StandbyOn();
                if (Scanner.GetState() != IDevice.State.on)
                {
                    Scanner.StandbyOff();
                }
                else if (ScansInRowCounter == 2)
                {
                    Scanner.StandbyOn();

                    ScansInRowCounter = 0;

                    Console.WriteLine("\nScanner in standby mode, please wait ...\n");

                    Scanner.StandbyOff();
                }

                ScansInRowCounter++;

                switch (formatType)
                {
                    case IDocument.FormatType.JPG:
                        document = new ImageDocument("ImageScan" + ScanCounter.ToString("D4") + ".jpg");
                        break;
                    case IDocument.FormatType.PDF:
                        document = new PDFDocument("PDFScan" + ScanCounter.ToString("D4") + ".pdf");
                        break;
                    case IDocument.FormatType.TXT:
                        document = new TextDocument("TextScan" + ScanCounter.ToString("D4") + ".txt");
                        break;
                }

                ScanCounter++;

                Console.WriteLine(DateTime.Now + " Scan: " + document.GetFileName());
            }
        }
        public void ScanAndPrint()
        {
            IDocument scannedDocument;
            Scan(out scannedDocument, formatType: IDocument.FormatType.JPG);
            Print(scannedDocument);
        }
    }
}