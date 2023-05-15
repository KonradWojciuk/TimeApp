using System.Globalization;
using TimeLibrary;

namespace TimeUntilTest
{
    [TestClass]
    public class UntilTestTimeConstructor
    {
        private static byte defaultValue = 0;

        [TestMethod]
        [DataRow((byte)13)]
        [DataRow((byte)8)]
        [DataRow((byte)21)]
        [DataRow((byte)12)]
        [DataRow((byte)0)]
        public void Constructor_With_Only_Hour(byte a)
        {
            Time time = new Time(hour: a);
            Assert.AreEqual(a, time.Hour);
            Assert.AreEqual(defaultValue, time.Minute);
            Assert.AreEqual(defaultValue, time.Second);
        }

        [TestMethod]
        [DataRow ((byte)21, (byte)10)]
        [DataRow((byte)12, (byte)40)]
        [DataRow((byte)9, (byte)32)]
        [DataRow((byte)1, (byte)43)]
        [DataRow((byte)0, (byte)21)]
        [DataRow((byte)0, (byte)0)]
        public void Constructor_With_Hour_And_Minute(byte a, byte b)
        {
            Time time = new Time(hour: a, minute: b);
            Assert.AreEqual(a, time.Hour);
            Assert.AreEqual(b, time.Minute);
            Assert.AreEqual(defaultValue, time.Second);
        }

        [TestMethod]
        [DataRow((byte)10, (byte)34, (byte)21)]
        [DataRow((byte)23, (byte)51, (byte)51)]
        [DataRow((byte)7, (byte)12, (byte)42)]
        [DataRow((byte)13, (byte)27, (byte)36)]
        [DataRow((byte)0, (byte)49, (byte)55)]
        [DataRow((byte)0, (byte)0, (byte)8)]
        [DataRow((byte)0, (byte)0, (byte)0)]
        public void Constructor_With_Hour_Minute_And_Second(byte a, byte b, byte c)
        {
            Time time = new Time(hour: a, minute: b, second: c);
            Assert.AreEqual(a, time.Hour);
            Assert.AreEqual(b, time.Minute);
            Assert.AreEqual(c, time.Second);
        }

        [TestMethod]
        [DataRow((byte)24, (byte)34, (byte)21)]
        [DataRow((byte)10, (byte)72, (byte)21)]
        [DataRow((byte)10, (byte)34, (byte)188)]
        [DataRow((byte)53, (byte)100, (byte)21)]
        [DataRow((byte)32, (byte)98, (byte)90)]
        [DataRow((byte)12, (byte)78, (byte)190)]
        [DataRow((byte)48, (byte)33, (byte)90)]
        [ExpectedException (typeof(ArgumentException))]
        public void Constructor_With_Invalid_Args(byte a, byte b, byte c)
        {
            Time time = new Time(a, b, c);
        }

        [TestMethod]
        [DataRow ("10:32:12", (byte)10, (byte)32, (byte)12)]
        [DataRow("14:00:00", (byte)14, (byte)0, (byte)0)]
        [DataRow("00:32:42", (byte)0, (byte)32, (byte)42)]
        [DataRow("00:00:33", (byte)0, (byte)0, (byte)33)]
        [DataRow("21:12:54", (byte)21, (byte)12, (byte)54)]
        public void Constructor_With_String_Arg(string a, byte expectedA, byte expectedB, byte expectedC)
        {
            Time time = new Time(a);
            Assert.AreEqual(expectedA, time.Hour);
            Assert.AreEqual(expectedB, time.Minute);
            Assert.AreEqual(expectedC, time.Second);
        }

        [TestMethod]
        [DataRow("10:32:12:112")]
        [DataRow("10:32:12:112:12312")]
        [DataRow("10:32:12:112:213:12")]
        [DataRow("10:32:12:112::")]
        [DataRow("10:32:12:112:::213")]
        [ExpectedException(typeof(FormatException))]
        public void String_Constructor_With_Invalid_Format(string a)
        {
            Time time = new Time(a);
        }

        [TestMethod]
        [DataRow("100:32:12")]
        [DataRow("10:324:12")]
        [DataRow("10:32:1221")]
        [DataRow("1002:3222:1222")]
        [DataRow("100:322:121")]
        [ExpectedException(typeof(ArgumentException))]
        public void String_Constructor_With_Invalid_Data(string a)
        {
            Time time = new Time(a);
        }

        [TestMethod]
        [DataRow((byte)10, (byte)32, (byte)12, "10:32:12")]
        [DataRow((byte)15, (byte)12, (byte)42, "15:12:42")]
        [DataRow((byte)00, (byte)32, (byte)12, "00:32:12")]
        [DataRow((byte)00, (byte)00, (byte)57, "00:00:57")]
        [DataRow((byte)23, (byte)39, (byte)00, "23:39:00")]
        public void ToString_Formmatable(byte a, byte b, byte c, string expectedString)
        {
            Time time = new Time(a, b, c);
            Assert.AreEqual(expectedString, time.ToString());
        }
    }
}