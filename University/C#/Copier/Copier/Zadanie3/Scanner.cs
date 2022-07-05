using System;

namespace Zadanie3
{
    public class Scanner : IScanner
    {
        public int ScanCounter { get; set; }
        public int Counter { get; set; }
        public IDevice.State GetState() => state;
        private IDevice.State state = IDevice.State.off;

        public void PowerOff()
        {
            if (state == IDevice.State.on)
            {
                state = IDevice.State.off;

                Console.WriteLine("... Scanner is off !");
            }
        }
        public void PowerOn()
        {
            if (state == IDevice.State.off)
            {
                Counter++;
                state = IDevice.State.on;

                Console.WriteLine("Scanner is on ...");
            }
        }
        public void Scan(out IDocument document, IDocument.FormatType formatType)
        {
            document = null;

            if (state == IDevice.State.on)
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
    }
}