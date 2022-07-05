using System;

namespace Zadanie2
{
    public class Copier : BaseDevice, IPrinter, IScanner
    {
        public int ScanCounter { get; set; }
        public int PrintCounter { get; set; }
        public new int Counter { get; set; }

        public new void PowerOn()
        {
            if (GetState() == IDevice.State.off)
            {
                Counter++;

                base.PowerOn();
            }
        }
        public void Print(in IDocument document)
        {
            if (GetState() == IDevice.State.on)
            {
                PrintCounter++;

                Console.WriteLine(DateTime.Now + " Print: " + document.GetFileName());
            }
        }
        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            document = null;

            if (GetState() == IDevice.State.on)
            {
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
            if (GetState() == IDevice.State.on)
            {
                IDocument document;
                Scan(out document, formatType: IDocument.FormatType.JPG);
                Print(document);
            }
        }
    }
}