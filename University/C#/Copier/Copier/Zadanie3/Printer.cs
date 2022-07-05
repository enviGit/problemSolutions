using System;

namespace Zadanie3
{
    public class Printer : IPrinter
    {
        public int PrintCounter { get; set; }
        public int Counter { get; set; }
        public IDevice.State GetState() => state;
        private IDevice.State state = IDevice.State.off;

        public void PowerOff()
        {
            if (state == IDevice.State.on)
            {
                state = IDevice.State.off;

                Console.WriteLine("... Printer is off !");
            }
        }
        public void PowerOn()
        {
            if (state == IDevice.State.off)
            {
                Counter++;
                state = IDevice.State.on;

                Console.WriteLine("Printer is on ...");
            }
        }
        public void Print(in IDocument document)
        {
            if (state == IDevice.State.on)
            {
                PrintCounter++;

                Console.WriteLine(DateTime.Now + " Print: " + document.GetFileName());
            }
        }
    }
}