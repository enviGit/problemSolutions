namespace Zadanie3
{
    public class MultidimensionalDevice : BaseDevice
    {
        private Printer Printer = new Printer();
        private Scanner Scanner = new Scanner();
        private Fax Fax = new Fax();
        public int PrintCounter => Printer.PrintCounter;
        public int ScanCounter => Scanner.ScanCounter;
        public int FaxCounter => Fax.FaxCounter;
        public new int Counter { get; set; }

        public new void PowerOff()
        {
            if (GetState() == IDevice.State.on)
            {
                Printer.PowerOff();
                Scanner.PowerOff();
                Fax.PowerOff();
                base.PowerOff();
            }
        }
        public new void PowerOn()
        {
            if (GetState() == IDevice.State.off)
            {
                Counter++;
                Printer.PowerOn();
                Scanner.PowerOn();
                Fax.PowerOn();
                base.PowerOn();
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
                Scan(out IDocument document, IDocument.FormatType.JPG);
                Print(in document);
            }
        }
        public void SendFax(in IDocument document, string receiver)
        {
            if (GetState() == IDevice.State.on)
            {
                Fax.SendFax(document, receiver);
            }
        }
    }
}
