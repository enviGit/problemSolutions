using System;
using System.Diagnostics.CodeAnalysis;

namespace TimeAndTimePeriod
{
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        public readonly long totalSeconds;
        public long Seconds { get => totalSeconds % 60; }
        public long Minutes { get => (totalSeconds / 60) % 60; }
        public long Hours { get => totalSeconds / 3600; }

        public TimePeriod(int hours, int minutes, int secs = 0)
        {
            totalSeconds = hours * 3600 + minutes * 60 + secs;
        }

        public TimePeriod(long seconds)
        {
            if (seconds < 0)
                seconds = 0;
            totalSeconds = seconds;
        }

        public TimePeriod(string time)
        {
            string[] str = time.Split(":");

            try
            {
                totalSeconds = Convert.ToInt32(str[2]) + Convert.ToInt32(str[1]) * 60 + Convert.ToInt32(str[0]) * 3600;
            }
            catch (Exception e)
            {
                throw new FormatException("Invalid format. The proper format is: 'hh:mm:ss'");
            }
        }

        public override string ToString() => String.Format("{0:D2}:{1:D2}:{2:D2}", Hours, Minutes, Seconds);
      
        public bool Equals([AllowNull] TimePeriod other)
        {
            if (other == null) 
                return false;

            return totalSeconds == other.totalSeconds;
        }
        public int CompareTo([AllowNull] TimePeriod other)
        {
            if (other == null) 
                return 1;

            long value = 3600 * (Hours - other.Hours);
            value += 60 * (Minutes - other.Minutes);
            value += Seconds - other.Seconds;
            
            return (int)value;
        }
        public override bool Equals(object obj) => obj is Time ? Equals((Time)obj) : base.Equals(obj);
        public override int GetHashCode() => (int)(Hours * Minutes * Seconds);

        public static bool operator ==(TimePeriod t1, TimePeriod t2) => t1.CompareTo(t2) == 0;
        public static bool operator !=(TimePeriod t1, TimePeriod t2) => t1.CompareTo(t2) != 0;
        public static bool operator <(TimePeriod t1, TimePeriod t2) => t1.CompareTo(t2) < 0;
        public static bool operator <=(TimePeriod t1, TimePeriod t2) => t1.CompareTo(t2) <= 0;
        public static bool operator >(TimePeriod t1, TimePeriod t2) => t1.CompareTo(t2) > 0;
        public static bool operator >=(TimePeriod t1, TimePeriod t2) => t1.CompareTo(t2) >= 0;

        public static TimePeriod operator +(TimePeriod tp1, TimePeriod tp2) => new TimePeriod(tp1.totalSeconds + tp2.totalSeconds);
        public static TimePeriod operator -(TimePeriod tp1, TimePeriod tp2) => new TimePeriod(tp1.totalSeconds - tp2.totalSeconds);
    }
}
