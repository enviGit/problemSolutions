using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Zadanie2;

namespace Zadanie2UnitTests
{
    public class ConsoleRedirectionToStringWriter : IDisposable
    {
        private StringWriter stringWriter;
        private TextWriter originalOutput;

        public ConsoleRedirectionToStringWriter()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }

        public string GetOutput()
        {
            return stringWriter.ToString();
        }

        public void Dispose()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }

    [TestClass]
    public class Zadanie2UnitTests
    {
        [TestMethod]
        public void MultifunctionalDevice_GetState_StateOff()
        {
            var mD = new MultifunctionalDevice();
            mD.PowerOff();

            Assert.AreEqual(IDevice.State.off, mD.GetState());
        }

        [TestMethod]
        public void MultifunctionalDevice_GetState_StateOn()
        {
            var mD = new MultifunctionalDevice();
            mD.PowerOn();

            Assert.AreEqual(IDevice.State.on, mD.GetState());
        }

        [TestMethod]
        public void MultifunctionalDevice_Print_DeviceOn()
        {
            var mD = new MultifunctionalDevice();
            mD.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                mD.Print(doc1);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Print"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void MultifunctionalDevice_Print_DeviceOff()
        {
            var mD = new MultifunctionalDevice();
            mD.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                mD.Print(doc1);
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Print"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void MultifunctionalDevice_Scan_DeviceOff()
        {
            var mD = new MultifunctionalDevice();
            mD.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1;
                mD.Scan(out doc1);
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Scan"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void MultifunctionalDevice_Scan_DeviceOn()
        {
            var mD = new MultifunctionalDevice();
            mD.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1;
                mD.Scan(out doc1);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void MultifunctionalDevice_Fax_DeviceOn()
        {
            var mD = new MultifunctionalDevice();
            mD.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                mD.Fax(doc1, "Receiver");
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Fax"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void MultifunctionalDevice_Fax_DeviceOff()
        {
            var mD = new MultifunctionalDevice();
            mD.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                mD.Fax(doc1, "Receiver");
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Fax"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void MultifunctionalDevice_Scan_FormatTypeDocument()
        {
            var mD = new MultifunctionalDevice();
            mD.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1;
                mD.Scan(out doc1, formatType: IDocument.FormatType.JPG);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains(".jpg"));

                mD.Scan(out doc1, formatType: IDocument.FormatType.TXT);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains(".txt"));

                mD.Scan(out doc1, formatType: IDocument.FormatType.PDF);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains(".pdf"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void MultifunctionalDevice_ScanAndPrint_DeviceOn()
        {
            var mD = new MultifunctionalDevice();
            mD.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                mD.ScanAndPrint();
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Print"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void MultifunctionalDevice_ScanAndPrint_DeviceOff()
        {
            var mD = new MultifunctionalDevice();
            mD.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                mD.ScanAndPrint();
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Print"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void MultifunctionalDevice_ScanAndFax_DeviceOn()
        {
            var mD = new MultifunctionalDevice();
            mD.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                mD.ScanAndFax("Receiver");
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Fax"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void MultifunctionalDevice_ScanAndFax_DeviceOff()
        {
            var mD = new MultifunctionalDevice();
            mD.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                mD.ScanAndFax("Receiver");
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Fax"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void MultifunctionalDevice_PrintCounter()
        {
            var mD = new MultifunctionalDevice();
            mD.PowerOn();

            IDocument doc1 = new PDFDocument("aaa.pdf");
            mD.Print(doc1);
            IDocument doc2 = new TextDocument("aaa.txt");
            mD.Print(doc2);
            IDocument doc3 = new ImageDocument("aaa.jpg");
            mD.Print(doc3);

            mD.PowerOff();
            mD.Print(doc3);
            mD.Scan(out doc1);
            mD.PowerOn();

            mD.ScanAndPrint();
            mD.ScanAndPrint();

            Assert.AreEqual(5, mD.PrintCounter);
        }

        [TestMethod]
        public void MultifunctionalDevice_ScanCounter()
        {
            var mD = new MultifunctionalDevice();
            mD.PowerOn();

            IDocument doc1;
            mD.Scan(out doc1);
            IDocument doc2;
            mD.Scan(out doc2);

            IDocument doc3 = new ImageDocument("aaa.jpg");
            mD.Print(doc3);

            mD.PowerOff();
            mD.Print(doc3);
            mD.Scan(out doc1);
            mD.PowerOn();

            mD.ScanAndPrint();
            mD.ScanAndPrint();

            Assert.AreEqual(4, mD.ScanCounter);
        }

        [TestMethod]
        public void MultifunctionalDevice_FaxCounter()
        {
            var mD = new MultifunctionalDevice();
            mD.PowerOn();

            IDocument doc1 = new PDFDocument("aaa.pdf");
            mD.Fax(doc1, "Receiver");

            IDocument doc2 = new ImageDocument("aaa.jpg");
            mD.Fax(doc2, "Receiver2");

            IDocument doc3 = new TextDocument("aaa.txt");
            mD.Fax(doc2, "Receiver3");

            Assert.AreEqual(3, mD.FaxCounter);
        }

        [TestMethod]
        public void MultifunctionalDevice_PowerOnCounter()
        {
            var mD = new MultifunctionalDevice();
            mD.PowerOn();
            mD.PowerOn();
            mD.PowerOn();

            IDocument doc1;
            mD.Scan(out doc1);
            IDocument doc2;
            mD.Scan(out doc2);

            mD.PowerOff();
            mD.PowerOff();
            mD.PowerOff();
            mD.PowerOn();

            IDocument doc3 = new ImageDocument("aaa.jpg");
            mD.Print(doc3);

            mD.PowerOff();
            mD.Print(doc3);
            mD.Scan(out doc1);
            mD.PowerOn();

            mD.ScanAndPrint();
            mD.ScanAndPrint();

            Assert.AreEqual(3, mD.Counter);
        }

    }
}