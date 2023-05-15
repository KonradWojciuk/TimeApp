using TimeLibrary;

namespace TimePeriodUnitTest
{
    [TestClass]
    public class UnitTestTimePeriodConstructor
    {
        [TestMethod]
        [DataRow((long) 122133)]
        [DataRow((long) 66756342321)]
        [DataRow((long) 86321512231)]
        [DataRow((long) 321554129921331231)]
        [DataRow((long) 4775154325436567658)]
        public void Constructor_TimePeriod_With_Seconds_Args(long a)
        {
            TimePeriod time = new TimePeriod(a);

            Assert.AreEqual(a, time.TotalSeconds);
        }

        [TestMethod]
        [DataRow((long)-122133)]
        [DataRow((long)-66756342321)]
        [DataRow((long)-86321512231)]
        [DataRow((long)-321554129921331231)]
        [DataRow((long)-4775154325436567658)]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_TimePeriod_With_Wrong_Seconds_Args(long a)
        {
            TimePeriod time = new TimePeriod(a);
        }

        [TestMethod]
        [DataRow((byte)13)]
        [DataRow((byte)8)]
        [DataRow((byte)21)]
        [DataRow((byte)12)]
        [DataRow((byte)0)]
        public void Constructor_TimePeriod_With_Only_Second_Arg(byte a)
        {
            TimePeriod time = new TimePeriod(seconds: a);

            Assert.AreEqual(a, time.Seconds);
            Assert.AreEqual(0, time.Minutes);
            Assert.AreEqual(0, time.Hours);
            Assert.AreEqual(a, time.TotalSeconds);
        }

        [TestMethod]
        [DataRow((byte)21, (byte)10)]
        [DataRow((byte)12, (byte)40)]
        [DataRow((byte)9, (byte)32)]
        [DataRow((byte)0, (byte)21)]
        [DataRow((byte)0, (byte)0)]
        public void Constructor_TimePeriod_With_Second_And_Minute_Args(byte a, byte b)
        {
            TimePeriod time = new TimePeriod(seconds: a, minute: b);

            Assert.AreEqual(a, time.Seconds);
            Assert.AreEqual(b, time.Minutes);
            Assert.AreEqual(0, time.Hours);
            Assert.AreEqual(time.Seconds + time.Minutes * 60, time.TotalSeconds);
        }

        [TestMethod]
        [DataRow((byte)10, (byte)34, (byte)21)]
        [DataRow((byte)23, (byte)51, (byte)51)]
        [DataRow((byte)0, (byte)49, (byte)55)]
        [DataRow((byte)0, (byte)0, (byte)8)]
        [DataRow((byte)0, (byte)0, (byte)0)]
        public void Constructor_TimePeriod_With_All_Args(byte a, byte b, byte c)
        {
            TimePeriod time = new TimePeriod(c, b, a);

            Assert.AreEqual(c, time.Seconds);
            Assert.AreEqual(b, time.Minutes);
            Assert.AreEqual(a, time.Hours);
            Assert.AreEqual(time.Seconds + time.Minutes * 60 + time.Hours * 3600, time.TotalSeconds);
        }

        [TestMethod]
        [DataRow("10:32:12", (byte)10, (byte)32, (byte)12)]
        [DataRow("14:00:00", (byte)14, (byte)0, (byte)0)]
        [DataRow("00:32:42", (byte)0, (byte)32, (byte)42)]
        [DataRow("00:00:33", (byte)0, (byte)0, (byte)33)]
        [DataRow("21:12:54", (byte)21, (byte)12, (byte)54)]
        public void Constructor_TimePeriod_With_String_Arg(string a, byte expectedA, byte expectedB, byte expectedC)
        {
            TimePeriod time = new TimePeriod(a);
            Assert.AreEqual(expectedA, time.Hours);
            Assert.AreEqual(expectedB, time.Minutes);
            Assert.AreEqual(expectedC, time.Seconds);
            Assert.AreEqual(expectedA * 3600 + expectedB * 60 + expectedC, time.TotalSeconds);
        }

        [TestMethod]
        [DataRow("10:32:12:112")]
        [DataRow("10:32:12:112:12312")]
        [DataRow("10:32:12:112:213:12")]
        [DataRow("10:32:12:112::")]
        [DataRow("10:32:12:112:::213")]
        [ExpectedException(typeof(FormatException))]
        public void String_Constructor_TimePeriod_With_Invalid_Format(string a)
        {
            TimePeriod time = new TimePeriod(a);
        }

        [TestMethod]
        [DataRow("10:46:39", "1:40:09", "9:06:30")]
        [DataRow("17:46:39", "7:00:00", "10:46:39")]
        [DataRow("10:46:39", "00:50:39", "9:56:00")]
        [DataRow("7:21:52", "4:31:57", "2:49:55")]
        [DataRow("22:50:40", "11:55:57", "10:54:43")]
        public void Constructor_With_Two_Times_Difference(string a, string b, string c)
        {
            Time time = new Time(a);
            Time time1 = new Time(b);
            TimePeriod timePeriod = new TimePeriod(time, time1);
            TimePeriod timePeriod1 = new TimePeriod(c);

            Assert.AreEqual(timePeriod.Hours, timePeriod1.Hours);
            Assert.AreEqual(timePeriod.Minutes, timePeriod1.Minutes);
            Assert.AreEqual(timePeriod.Seconds, timePeriod1.Seconds);
            Assert.AreEqual(timePeriod.TotalSeconds, timePeriod1.TotalSeconds);
        }

        [TestMethod]
        [DataRow("10:46:39", "16:42:59")]
        [DataRow("9:23:39", "12:11:42")]
        [DataRow("22:54:22", "23:10:10")]
        [DataRow("10:46:39", "10:51:12")]
        [DataRow("10:46:39", "10:46:59")]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_With_Two_Times_Difference_With_Greater_Second_Arg(string a, string b)
        {
            Time time = new Time(a);
            Time time1 = new Time(b);
            TimePeriod timePeriod = new TimePeriod(time, time1);
        }

        [TestMethod]
        [DataRow((byte)10, (byte)32, (byte)12, "10:32:12")]
        [DataRow((byte)15, (byte)12, (byte)42, "15:12:42")]
        [DataRow((byte)00, (byte)32, (byte)12, "0:32:12")]
        [DataRow((byte)00, (byte)00, (byte)57, "0:00:57")]
        [DataRow((byte)23, (byte)39, (byte)00, "23:39:00")]
        public void ToString_Formmatable(byte a, byte b, byte c, string expectedString)
        {
            TimePeriod time = new TimePeriod(c, b, a);
            Assert.AreEqual(expectedString, time.ToString());
        }
    }
}