using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLibrary;

namespace TimeUntilTest
{
    [TestClass]
    public class UntilTestTimeEqutableComperableAndOperators
    {
        [TestMethod]
        [DataRow((byte)10, (byte)34, (byte)21, "10:34:21")]
        [DataRow((byte)23, (byte)51, (byte)51, "23:51:51")]
        [DataRow((byte)7, (byte)12, (byte)42, "7:12:42")]
        [DataRow((byte)13, (byte)27, (byte)36, "13:27:36")]
        [DataRow((byte)18, (byte)49, (byte)55, "18:49:55")]
        public void Equals_Return_True(byte a, byte b, byte c, string d)
        {
            Time time = new Time(a, b, c);
            Time time1 = new Time(d);

            Assert.IsTrue(time.Equals(time1));
        }

        [TestMethod]
        [DataRow((byte)15, (byte)34, (byte)21, "10:34:21")]
        [DataRow((byte)23, (byte)51, (byte)51, "13:51:51")]
        [DataRow((byte)8, (byte)12, (byte)42, "7:12:42")]
        [DataRow((byte)13, (byte)27, (byte)56, "13:27:36")]
        [DataRow((byte)18, (byte)59, (byte)55, "18:19:55")]
        public void Equals_Return_False(byte a, byte b, byte c, string d)
        {
            Time time = new Time(a, b, c);
            Time time1 = new Time(d);

            Assert.IsFalse(time.Equals(time1));
        }

        [TestMethod]
        [DataRow((byte)10, (byte)34, (byte)21, "10:34:21")]
        [DataRow((byte)23, (byte)51, (byte)51, "23:51:51")]
        [DataRow((byte)7, (byte)12, (byte)42, "7:12:42")]
        [DataRow((byte)13, (byte)27, (byte)36, "13:27:36")]
        [DataRow((byte)18, (byte)49, (byte)55, "18:49:55")]
        public void CompareTo_Return_True(byte a, byte b, byte c, string d)
        {
            Time time = new Time(a, b, c);
            Time time1 = new Time(d);

            Assert.IsTrue(time.CompareTo(time1) == 0);
        }

        [TestMethod]
        [DataRow((byte)15, (byte)34, (byte)21, "10:34:21")]
        [DataRow((byte)23, (byte)51, (byte)51, "13:51:51")]
        [DataRow((byte)8, (byte)12, (byte)42, "7:12:42")]
        [DataRow((byte)13, (byte)27, (byte)56, "13:27:36")]
        [DataRow((byte)18, (byte)59, (byte)55, "18:19:55")]
        public void CompareTo_Return_False(byte a, byte b, byte c, string d)
        {
            Time time = new Time(a, b, c);
            Time time1 = new Time(d);

            Assert.IsFalse(time.CompareTo(time1) < 0);
        }

        [TestMethod]
        [DataRow((byte)10, (byte)34, (byte)21, "10:34:21", "00:00:00")]
        [DataRow((byte)23, (byte)51, (byte)51, "23:51:51", "00:00:00")]
        [DataRow((byte)7, (byte)12, (byte)42, "7:12:42", "00:00:00")]
        [DataRow((byte)13, (byte)27, (byte)36, "13:27:36", "00:00:00")]
        [DataRow((byte)18, (byte)49, (byte)55, "18:49:55", "00:00:00")]
        public void Operator_Equals_Return_CorrectValue(byte a, byte b, byte c, string d, string falseValue)
        {
            Time time = new Time(a, b, c);
            Time time1 = new Time(d);
            Time time2 = new Time(falseValue);

            Assert.IsTrue(time == time1);
            Assert.IsFalse(time == time2);
        }

        [TestMethod]
        [DataRow((byte)15, (byte)34, (byte)21, "10:34:21", "15:34:21")]
        [DataRow((byte)23, (byte)51, (byte)51, "13:51:51", "23:51:51")]
        [DataRow((byte)8, (byte)12, (byte)42, "7:12:42", "8:12:42")]
        [DataRow((byte)13, (byte)27, (byte)56, "13:27:36", "13:27:56")]
        [DataRow((byte)18, (byte)59, (byte)55, "18:19:55", "18:59:55")]
        public void Operator_NotEqual_Return_Correct_Value(byte a, byte b, byte c, string d, string falseValue)
        {
            Time time = new Time(a, b, c);
            Time time1 = new Time(d);
            Time time2 = new Time(falseValue);

            Assert.IsTrue(time != time1);
            Assert.IsFalse(time != time2);
        }

        [TestMethod]
        [DataRow("10:34:21", "15:34:21")]
        [DataRow("12:22:11", "13:44:51")]
        [DataRow("8:34:21", "20:34:21")]
        [DataRow("14:34:21", "18:34:21")]
        [DataRow("1:45:51", "5:24:46")]
        public void Operator_Less_Return_Correct_Value(string a, string b)
        {
            Time time = new Time(a);
            Time time1 = new Time(b);

            Assert.IsTrue(time < time1);
        }

        [TestMethod]
        [DataRow("10:34:21", "10:34:21")]
        [DataRow("12:12:11", "13:44:51")]
        [DataRow("18:26:21", "20:34:21")]
        [DataRow("14:34:21", "14:34:21")]
        [DataRow("11:45:51", "15:24:46")]
        public void Operator_Less_Or_Equal_Return_Correct_Value(string a, string b)
        {
            Time time = new Time(a);
            Time time1 = new Time(b);

            Assert.IsTrue(time <= time1);
        }

        [TestMethod]
        [DataRow("18:26:31", "16:42:21")]
        [DataRow("18:36:31", "18:22:21")]
        [DataRow("18:42:31", "18:42:21")]
        [DataRow("7:45:17", "4:30:00")]
        [DataRow("22:51:28", "7:13:41")]
        public void Operator_More_Return_Correct_Value(string a, string b)
        {
            Time time = new Time(a);
            Time time1 = new Time(b);

            Assert.IsTrue(time > time1);
        }

        [TestMethod]
        [DataRow("18:26:31", "18:26:31")]
        [DataRow("18:36:31", "18:22:21")]
        [DataRow("18:42:31", "18:42:21")]
        [DataRow("4:30:00", "4:30:00")]
        [DataRow("22:51:28", "7:13:41")]
        public void Operator_More_Or_Equal_Return_Correct_Value(string a, string b)
        {
            Time time = new Time(a);
            Time time1 = new Time(b);

            Assert.IsTrue(time >= time1);
        }

        [TestMethod]
        [DataRow("10:21:21", "12:36:31", "22:57:52")]
        [DataRow("12:22:11", "13:44:51", "2:07:02")]
        [DataRow("8:34:21", "20:34:21", "5:08:42")]
        [DataRow("14:34:21", "7:14:21", "21:48:42")]
        [DataRow("1:45:51", "5:24:46", "7:10:37")]
        public void Plus_Method(string a, string b, string expected)
        {
            Time time = new Time(a);
            TimePeriod time1 = new TimePeriod(b);
            Time expectedTime = new Time(expected);

            var result = time.Plus(time1);

            Assert.AreEqual(result, expectedTime);
        }

        [TestMethod]
        [DataRow("10:21:21", "12:36:31", "22:57:52")]
        [DataRow("12:22:11", "13:44:51", "2:07:02")]
        [DataRow("8:34:21", "20:34:21", "5:08:42")]
        [DataRow("14:34:21", "7:14:21", "21:48:42")]
        [DataRow("1:45:51", "5:24:46", "7:10:37")]
        public void Plus_Static_Method(string a, string b, string expected)
        {
            Time time = new Time(a);
            TimePeriod timePeriod = new TimePeriod(b);
            Time time1 = new Time(expected);

            var result = Time.TimeAddition(time, timePeriod);

            Assert.AreEqual(result, time1);
        }

        [TestMethod]
        [DataRow("10:21:21", "12:36:31", "22:57:52")]
        [DataRow("12:22:11", "13:44:51", "2:07:02")]
        [DataRow("8:34:21", "20:34:21", "5:08:42")]
        [DataRow("14:34:21", "7:14:21", "21:48:42")]
        [DataRow("1:45:51", "5:24:46", "7:10:37")]
        public void Operator_Plus(string a, string b, string expected)
        {
            Time time = new Time(a);
            TimePeriod time1 = new TimePeriod(b);
            Time expectedTime = new Time(expected);

            var result = time + time1;

            Assert.AreEqual(result, expectedTime);
        }

        [TestMethod]
        [DataRow("12:00:00", "10:00:00", "2:00:00")]
        [DataRow("12:00:00", "10:30:00", "1:30:00")]
        [DataRow("14:00:00", "7:30:20", "6:29:40")]
        [DataRow("23:45:42", "17:46:17", "5:59:25")]
        [DataRow("4:22:20", "4:22:20", "00:00:00")]
        public void Minus_Method(string a, string b, string expected)
        {
            Time time = new Time(a);
            TimePeriod time1 = new TimePeriod(b);
            Time expectedTime = new Time(expected);

            var result = time.Minus(time1);

            Assert.AreEqual(result, expectedTime);
        }

        [TestMethod]
        [DataRow("12:00:00", "10:00:00", "2:00:00")]
        [DataRow("12:00:00", "10:30:00", "1:30:00")]
        [DataRow("14:00:00", "7:30:20", "6:29:40")]
        [DataRow("23:45:42", "17:46:17", "5:59:25")]
        [DataRow("4:22:20", "4:22:20", "00:00:00")]
        public void Minus_Static_Method(string a, string b, string expected)
        {
            Time time = new Time(a);
            TimePeriod time1 = new TimePeriod(b);
            Time expectedTime = new Time(expected);

            var result = time - time1;

            Assert.AreEqual(result, expectedTime);
        }

        [TestMethod]
        [DataRow("4:00:00", "10:00:00")]
        [DataRow("8:00:00", "10:30:00")]
        [DataRow("13:45:42", "17:46:17")]
        [DataRow("4:22:20", "6:22:20")]
        [DataRow("4:22:20", "4:23:20")]
        [ExpectedException(typeof(ArgumentException))]
        public void Minus_Method_Throw_ArgumentException_Error(string a, string b)
        {
            Time time = new Time(a);
            TimePeriod time1 = new TimePeriod(b);

            var result = time.Minus(time1);
        }

        [TestMethod]
        [DataRow("4:00:00", "10:00:00")]
        [DataRow("8:00:00", "10:30:00")]
        [DataRow("13:45:42", "17:46:17")]
        [DataRow("4:22:20", "6:22:20")]
        [DataRow("4:22:20", "4:23:20")]
        [ExpectedException(typeof(ArgumentException))]
        public void Minus_Static_Method_Throw_ArgumentException_Error(string a, string b)
        {
            Time time = new Time(a);
            TimePeriod time1 = new TimePeriod(b);

            var result = time.Minus(time1);
        }

        [TestMethod]
        [DataRow("12:00:00", "10:00:00", "2:00:00")]
        [DataRow("12:00:00", "10:30:00", "1:30:00")]
        [DataRow("14:00:00", "7:30:20", "6:29:40")]
        [DataRow("23:45:42", "17:46:17", "5:59:25")]
        [DataRow("4:22:20", "4:22:20", "00:00:00")]
        public void Operator_Minus(string a, string b, string expected)
        {
            Time time = new Time(a);
            TimePeriod time1 = new TimePeriod(b);
            Time expectedTime = new Time(expected);

            var result = time - time1;

            Assert.AreEqual(result, expectedTime);
        }
    }
}
