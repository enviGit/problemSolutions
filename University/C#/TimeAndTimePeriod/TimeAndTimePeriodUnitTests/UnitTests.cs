using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeAndTimePeriod;

namespace UnitTests
{
    [TestClass]
    [TestCategory("Time")]
    public class TimeUnitTests
    {
        [TestMethod]
        public void Time_ConstructorBasic()
        {
            Time time = new Time();
            Assert.AreEqual(0, time.Hours);
            Assert.AreEqual(0, time.Minutes);
            Assert.AreEqual(0, time.Seconds);

            time = new Time(12);
            Assert.AreEqual(12, time.Hours);
            Assert.AreEqual(0, time.Minutes);
            Assert.AreEqual(0, time.Seconds);

            time = new Time(15, 35);
            Assert.AreEqual(15, time.Hours);
            Assert.AreEqual(35, time.Minutes);
            Assert.AreEqual(0, time.Seconds);

            time = new Time(3, 25, 10);
            Assert.AreEqual(3, time.Hours);
            Assert.AreEqual(25, time.Minutes);
            Assert.AreEqual(10, time.Seconds);
        }

        [TestMethod]
        public void Time_ConstructString()
        {
            Time time = new Time("7:00:15");
            Assert.AreEqual(7, time.Hours);
            Assert.AreEqual(0, time.Minutes);
            Assert.AreEqual(15, time.Seconds);

            time = new Time("08:11:14");
            Assert.AreEqual(8, time.Hours);
            Assert.AreEqual(11, time.Minutes);
            Assert.AreEqual(14, time.Seconds);

            time = new Time("12:00:00");
            Assert.AreEqual(12, time.Hours);
            Assert.AreEqual(0, time.Minutes);
            Assert.AreEqual(0, time.Seconds);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Time_ConstructWrongFormat()
        {
            Time time = new Time("InvalidFormat");
            Assert.AreEqual(0, time.Seconds);
            Assert.AreEqual(0, time.Minutes);
            Assert.AreEqual(0, time.Hours);
        }

        [DataTestMethod]
        [DataRow("24:60:60")]
        [DataRow("24:00:00")]
        [DataRow("23:60:59")]
        [DataRow("01:59:60")]
        [DataRow("20:123:54321")]
        [ExpectedException(typeof(ArgumentException))]
        public void Time_ConstructWrongTime(string str)
        {
            Time time = new Time(str);
            Assert.AreEqual(0, time.Seconds);
            Assert.AreEqual(0, time.Minutes);
            Assert.AreEqual(0, time.Hours);
        }

        [DataTestMethod]
        [DataRow(23, 59, 59, "23:59:59")]
        [DataRow(0, 0, 0, "00:00:00")]
        [DataRow(12, 0, 13, "12:00:13")]
        public void Time_ToStringFunction(int h, int m, int s, string expected)
        {
            Time time = new Time((byte)h, (byte)m, (byte)s);
            Assert.AreEqual(expected, time.ToString());
        }

        [TestMethod]
        public void Time_Comparision()
        {
            Time time = new Time(12, 59, 10);
            Time time2 = new Time(20, 35, 40);
            Time time3 = new Time(12, 59, 10);
            Time time4 = new Time(15, 25, 15);

            Assert.IsTrue(time == time3);
            Assert.IsTrue(time2 != time4);
            Assert.IsTrue(time < time2);
            Assert.IsTrue(time3 <= time);
            Assert.IsTrue(time2 > time4);
            Assert.IsTrue(time3 >= time);

            Assert.IsFalse(time == time4);
            Assert.IsFalse(time != time3);
            Assert.IsFalse(time2 < time);
            Assert.IsFalse(time2 <= time4);
            Assert.IsFalse(time4 > time2);
            Assert.IsFalse(time3 >= time2);
        }

        [TestMethod]
        public void Time_Adding()
        {
            Time time = new Time();
            Time time2 = new Time(13, 45, 0);
            TimePeriod timePeriod = new TimePeriod(12, 30);
            TimePeriod timePeriod2 = new TimePeriod(0, 30, 30);

            Assert.AreEqual(new Time("12:30:00"), time + timePeriod);
            Assert.AreEqual(new Time("13:00:30"), time + timePeriod + timePeriod2);
            Assert.AreEqual(new Time("3:15:00"), time2 + timePeriod);
        }

        [TestMethod]
        public void Time_Substract()
        {
            Time time = new Time();
            Time time2 = new Time(13, 45, 0);
            TimePeriod timePeriod = new TimePeriod(12, 30);
            TimePeriod timePeriod2 = new TimePeriod(0, 30, 30);

            Assert.AreEqual(new Time("10:30:00"), time - timePeriod);
            Assert.AreEqual(new Time("1:15:00"), time2 - timePeriod);
            Assert.AreEqual(new Time("9:59:30"), (time - timePeriod) - timePeriod2);
        }
    }



    [TestClass]
    [TestCategory("TimePeriod")]
    public class TimePeriodUnitTests
    {
        [TestMethod]
        public void TimePeriod_ConstructorBasic()
        {
            TimePeriod time = new TimePeriod();
            Assert.AreEqual(0, time.totalSeconds);

            time = new TimePeriod(12);
            Assert.AreEqual(0, time.Hours);
            Assert.AreEqual(0, time.Minutes);
            Assert.AreEqual(12, time.Seconds);

            time = new TimePeriod(20, 35);
            Assert.AreEqual(20, time.Hours);
            Assert.AreEqual(35, time.Minutes);
            Assert.AreEqual(0, time.Seconds);

            time = new TimePeriod(1, 5, 10);
            Assert.AreEqual(1, time.Hours);
            Assert.AreEqual(5, time.Minutes);
            Assert.AreEqual(10, time.Seconds);
        }

        [TestMethod]
        public void TimePeriod_ConstructString()
        {
            TimePeriod time = new TimePeriod("15:00:30");
            Assert.AreEqual(15, time.Hours);
            Assert.AreEqual(0, time.Minutes);
            Assert.AreEqual(30, time.Seconds);

            time = new TimePeriod("12:00:00");
            Assert.AreEqual(12, time.Hours);
            Assert.AreEqual(0, time.Minutes);
            Assert.AreEqual(0, time.Seconds);

            time = new TimePeriod("01:05:10");
            Assert.AreEqual(1, time.Hours);
            Assert.AreEqual(5, time.Minutes);
            Assert.AreEqual(10, time.Seconds);

            time = new TimePeriod("48:69:00");
            Assert.AreEqual(49, time.Hours);
            Assert.AreEqual(9, time.Minutes);
            Assert.AreEqual(0, time.Seconds);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TimePeriod_ConstructWrongFormat()
        {
            TimePeriod time = new TimePeriod("wrong_format");
        }

        [DataTestMethod]
        [DataRow(23, 59, 59, "23:59:59")]
        [DataRow(0, 0, 0, "00:00:00")]
        [DataRow(12, 0, 13, "12:00:13")]
        [DataRow(30, 0, 13, "30:00:13")]
        [DataRow(13, 30, 1, "13:30:01")]
        public void TimePeriod_ToStringFunction(int h, int m, int s, string expected)
        {
            TimePeriod time = new TimePeriod((byte)h, (byte)m, (byte)s);
            Assert.AreEqual(expected, time.ToString());
        }

        [TestMethod]
        public void TimePeriod_Comparision()
        {
            TimePeriod time = new TimePeriod(12, 59, 10);
            TimePeriod time2 = new TimePeriod(20, 35, 40);
            TimePeriod time3 = new TimePeriod(12, 59, 10);
            TimePeriod time4 = new TimePeriod(15, 25, 15);

            Assert.IsTrue(time == time3);
            Assert.IsTrue(time2 != time4);
            Assert.IsTrue(time < time2);
            Assert.IsTrue(time3 <= time);
            Assert.IsTrue(time2 > time4);
            Assert.IsTrue(time3 >= time);

            Assert.IsFalse(time == time4);
            Assert.IsFalse(time != time3);
            Assert.IsFalse(time2 < time);
            Assert.IsFalse(time2 <= time4);
            Assert.IsFalse(time4 > time2);
            Assert.IsFalse(time3 >= time2);
        }

        [TestMethod]
        public void TimePeriod_Adding()
        {
            TimePeriod timePeriod = new TimePeriod(12, 30);
            TimePeriod timePeriod2 = new TimePeriod(0, 50, 30);
            TimePeriod timePeriod3 = new TimePeriod(10, 45, 25);

            Assert.AreEqual(new TimePeriod("13:20:30"), timePeriod + timePeriod2);
            Assert.AreEqual(new TimePeriod("11:35:55"), timePeriod2 + timePeriod3);
            Assert.AreEqual(new TimePeriod("37:30:00"), timePeriod + timePeriod + timePeriod);
        }

        [TestMethod]
        public void TimePeriod_Substract()
        {
            TimePeriod timePeriod = new TimePeriod(12, 30);
            TimePeriod timePeriod2 = new TimePeriod(0, 30, 30);
            TimePeriod timePeriod3 = new TimePeriod(13, 45, 1);

            Assert.AreEqual(new TimePeriod(), timePeriod2 - timePeriod);
            Assert.AreEqual(new TimePeriod("1:15:01"), timePeriod3 - timePeriod);
            Assert.AreEqual(new TimePeriod("12:44:01"), timePeriod3 - timePeriod2 - timePeriod2);
        }
    }
}
