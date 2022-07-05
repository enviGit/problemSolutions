using System;
using System.Diagnostics.CodeAnalysis;

namespace TimeAndTimePeriod
{
    public struct Time : IEquatable<Time>, IComparable<Time>
    {
        public readonly byte Seconds;
        public readonly byte Minutes;
        public readonly byte Hours;

        public Time(byte h, byte m = 0, byte s = 0)
        {
            Seconds = (byte)(s % 60);
            m += (byte)(s / 60);
            Minutes = (byte)(m % 60);
            h += (byte)(m / 60);
            Hours = (byte)(h % 24);
        }

        public Time(string time)
        {
            string[] str = time.Split(":");

            try
            {
                Hours = Convert.ToByte(str[0]);
                Minutes = Convert.ToByte(str[1]);
                Seconds = Convert.ToByte(str[2]);

                Validation();
            }
            catch (Exception e)
            {
                if (e is ArgumentException || e is OverflowException) 
                    throw new ArgumentException(e.Message);

                throw new FormatException("Invalid format. The proper format is: 'hh:mm:ss'");
            }
        }
        private void Validation()
        {
            if (Seconds < 0 || Seconds > 59)
                throw new ArgumentException("s has to be in range (0,59)");
            if (Minutes < 0 || Minutes > 59)
                throw new ArgumentException("m has to be in range (0,59)");
            if (Hours < 0 || Hours > 23)
                throw new ArgumentException("h has to be in range (0,23)");
        }

        public override string ToString() => String.Format("{0:D2}:{1:D2}:{2:D2}", Hours, Minutes, Seconds);

        public bool Equals([AllowNull] Time other)
        {
            if (other == null) 
                return false;

            return Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds;
        }
        public int CompareTo([AllowNull] Time other)
        {
            if (other == null) 
                return 1;

            int value = 3600 * (Hours - other.Hours);
            value += 60 * (Minutes - other.Minutes);
            value += Seconds - other.Seconds;

            return value;
        }
        public override bool Equals(object obj) => obj is Time ? Equals((Time)obj) : base.Equals(obj);
        public override int GetHashCode() => Hours * Minutes * Seconds;

        public static bool operator ==(Time t1, Time t2) => t1.CompareTo(t2) == 0;
        public static bool operator !=(Time t1, Time t2) => t1.CompareTo(t2) != 0;
        public static bool operator <(Time t1, Time t2) => t1.CompareTo(t2) < 0;
        public static bool operator <=(Time t1, Time t2) => t1.CompareTo(t2) <= 0;
        public static bool operator >(Time t1, Time t2) => t1.CompareTo(t2) > 0;
        public static bool operator >=(Time t1, Time t2) => t1.CompareTo(t2) >= 0;

        public static Time operator +(Time time, TimePeriod tp)
        {
            byte seconds = (byte)(time.Seconds + tp.Seconds);
            byte minutes = (byte)(time.Minutes + tp.Minutes + seconds / 60);
            byte hours = (byte)(time.Hours + tp.Hours + minutes / 60);

            return new Time((byte)(hours % 23), (byte)(minutes % 60), (byte)(seconds % 60));
        }
        public static Time operator -(Time time, TimePeriod tp)
        {
            int seconds = (int)(time.Seconds - tp.Seconds);
            int minutes = (int)(time.Minutes - tp.Minutes);
            int hours = (int)(time.Hours - tp.Hours);

            while (true)
            {
                if (hours < 0)
                {
                    hours = 23 + hours;

                    continue;
                }
                if (minutes < 0)
                {
                    minutes = 60 + minutes;
                    hours--;

                    continue;
                }
                if (seconds < 0)
                {
                    seconds = 60 + seconds;
                    minutes--;

                    continue;
                }

                break;
            }

            return new Time((byte)(hours % 23), (byte)(minutes % 60), (byte)(seconds % 60));
        }
    }
}