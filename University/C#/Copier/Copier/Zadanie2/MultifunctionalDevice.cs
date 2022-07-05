using System;

namespace Zadanie2
{
    public class MultifunctionalDevice : Copier, IFax
    {
        public int FaxCounter { get; set; }

        public void Fax(in IDocument document, string receiver)
        {
            if (GetState() == IDevice.State.on)
            {
                FaxCounter++;

                Console.WriteLine(DateTime.Now + " Fax: " + document.GetFileName() + " sent to " + receiver);
            }
        }

        public void ScanAndFax(string receiver)
        {
            if (GetState() == IDevice.State.on)
            {
                Scan(out IDocument document);
                Fax(in document, receiver);
            }
        }
    }
}