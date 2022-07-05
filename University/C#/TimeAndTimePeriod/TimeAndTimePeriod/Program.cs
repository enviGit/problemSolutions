using System;
using System.Threading;

namespace TimeAndTimePeriod
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;
            Time time = new Time((byte)now.Hour, (byte)now.Minute, (byte)now.Second);
            Time stoper = new Time();
            TimePeriod second = new TimePeriod(1);
            

            while (true)
            {
                Console.Clear();
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "\t//////////////////////////"), Console.ForegroundColor = ConsoleColor.Magenta);
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "\t/ Godzina:\t" + time + " /"), Console.ForegroundColor = ConsoleColor.Blue);
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "/ Stoper:\t" + stoper + " /"), Console.ForegroundColor = ConsoleColor.Blue);
                Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "\t//////////////////////////\n"), Console.ForegroundColor = ConsoleColor.Magenta);
                Console.WriteLine("Aby zakończyć program wciśnij 'E' lub 'ESC'", Console.ForegroundColor = ConsoleColor.DarkRed);

                if (Console.KeyAvailable && (Console.ReadKey().Key == ConsoleKey.Escape || Console.ReadKey().Key == ConsoleKey.E))
                    break;

                Thread.Sleep(1000);

                time += second;
                stoper += second;
                
            }
        }
    }
}
