using System;

namespace Zadanie3
{
    public class Fax : IFax
    {
        public int FaxCounter { get; set; }
        public int Counter { get; set; }
        public IDevice.State GetState() => state;
        private IDevice.State state = IDevice.State.off;

        public void PowerOff()
        {
            if (state == IDevice.State.on)
            {
                state = IDevice.State.off;

                Console.WriteLine("... Fax is off !");
            }
        }
        public void PowerOn()
        {
            if (state == IDevice.State.off)
            {
                Counter++;
                state = IDevice.State.on;

                Console.WriteLine("Fax is on ...");
            }
        }
        public void SendFax(in IDocument document, string receiver)
        {
            if (state == IDevice.State.on)
            {
                FaxCounter++;

                Console.WriteLine(DateTime.Now + " Fax: " + document.GetFileName() + " sent to " + receiver);
            }
        }
    }
}