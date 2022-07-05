namespace Zadanie3
{
    public class Copier : BaseDevice
    {
        private IPrinter Printer = new Printer();
        private IScanner Scanner = new Scanner();
        public int PrintCounter => Printer.PrintCounter;
        public int ScanCounter => Scanner.ScanCounter;
        public new int Counter { get; set; }

        public new void PowerOff()
        {
            if (GetState() == IDevice.State.on)
            {
                Printer.PowerOff();
                Scanner.PowerOff();
                base.PowerOff();
            }
        }
        public new void PowerOn()
        {
            if (GetState() == IDevice.State.off)
            {
                Counter++;

                base.PowerOn();
                Printer.PowerOn();
                Scanner.PowerOn();
            }
        }
        public void Print(in IDocument document)
        {
            if (GetState() == IDevice.State.on)
            {
                Printer.Print(document);
            }
        }
        public void Scan(out IDocument document, IDocument.FormatType formatType = IDocument.FormatType.JPG)
        {
            document = null;

            if (GetState() == IDevice.State.on)
            {
                Scanner.Scan(out document, formatType);
            }
        }
        public void ScanAndPrint()
        {
            if (GetState() == IDevice.State.on)
            {
                IDocument document;
                Scan(out document, IDocument.FormatType.JPG);
                Print(in document);
            }
        }
    }
}