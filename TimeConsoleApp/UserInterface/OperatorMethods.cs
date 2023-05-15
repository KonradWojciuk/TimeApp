using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLibrary;

namespace TimeConsoleApp.UserInterface
{
    public class OperatorMethods
    {
        public static void EqualsTime(Time time, Time time1)
        {
            if (time == time1)
                Console.WriteLine(time.ToString() + " is equal to " + time1.ToString() + "\n");
            else
                Console.WriteLine(time.ToString() + " is not equal to " + time1.ToString() + "\n");
        }

        public static void NotEqualsTime(Time time, Time time1)
        {
            if (time != time1)
                Console.WriteLine(time.ToString() + " is diffrent than " + time1.ToString() + "\n");
            else
                Console.WriteLine(time.ToString() + " is not diffrent than " + time1.ToString() + "\n");
        }

        public static void LowerTime(Time time, Time time1)
        {
            if (time < time1)
                Console.WriteLine(time.ToString() + " is lower than " + time1.ToString() + "\n");
            else
                Console.WriteLine(time.ToString() + " is not lower than " + time1.ToString() + "\n");
        }

        public static void LowerOrEqualsTime(Time time, Time time1)
        {
            if (time <= time1)
                Console.WriteLine(time.ToString() + " is lower or equal than " + time1.ToString() + "\n");
            else
                Console.WriteLine(time.ToString() + " is not lower or equal than " + time1.ToString() + "\n");
        }

        public static void BiggerTime(Time time, Time time1)
        {
            if (time > time1)
                Console.WriteLine(time.ToString() + " is bigger than " + time1.ToString() + "\n");
            else
                Console.WriteLine(time.ToString() + " is not bigger than " + time1.ToString() + "\n");
        }

        public static void BiggerOrEqualsTime(Time time, Time time1)
        {
            if (time > time1)
                Console.WriteLine(time.ToString() + " is bigger or eqaul than " + time1.ToString() + "\n");
            else
                Console.WriteLine(time.ToString() + " is not bigger or eqaul than " + time1.ToString() + "\n");
        }

        public static void EqualsTimePeriod(TimePeriod time, TimePeriod time1)
        {
            if (time == time1)
                Console.WriteLine(time.ToString() + " is equal to " + time1.ToString() + "\n");
            else
                Console.WriteLine(time.ToString() + " is not equal to " + time1.ToString() + "\n");
        }

        public static void NotEqualsTimePeriod(TimePeriod time, TimePeriod time1)
        {
            if (time != time1)
                Console.WriteLine(time.ToString() + " is diffrent than " + time1.ToString() + "\n");
            else
                Console.WriteLine(time.ToString() + " is not diffrent than " + time1.ToString() + "\n");
        }

        public static void LowerTimePeriod(TimePeriod time, TimePeriod time1)
        {
            if (time < time1)
                Console.WriteLine(time.ToString() + " is lower than " + time1.ToString() + "\n");
            else
                Console.WriteLine(time.ToString() + " is not lower than " + time1.ToString() + "\n");
        }

        public static void LowerOrEqualsTimePeriod(TimePeriod time, TimePeriod time1)
        {
            if (time <= time1)
                Console.WriteLine(time.ToString() + " is lower or equal than " + time1.ToString() + "\n");
            else
                Console.WriteLine(time.ToString() + " is not lower or equal than " + time1.ToString() + "\n");
        }

        public static void BiggerTimePeriod(TimePeriod time, TimePeriod time1)
        {
            if (time > time1)
                Console.WriteLine(time.ToString() + " is bigger than " + time1.ToString() + "\n");
            else
                Console.WriteLine(time.ToString() + " is not bigger than " + time1.ToString() + "\n");
        }

        public static void BiggerOrEqualsTimePeriod(TimePeriod time, TimePeriod time1)
        {
            if (time > time1)
                Console.WriteLine(time.ToString() + " is bigger or eqaul than " + time1.ToString() + "\n");
            else
                Console.WriteLine(time.ToString() + " is not bigger or eqaul than " + time1.ToString() + "\n");
        }
    }
}
