using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLibrary;

namespace TimeConsoleApp.UserInterface
{
    public class HelpMethods
    {
        public static void ShowMenu()
        {
            Console.WriteLine("What you want to do with your time?");
            Console.WriteLine("1. Write out the time.");
            Console.WriteLine("2. Use operator '==', '!=', '<', '<=', '>' or '>=' to compare the second time.");
            Console.WriteLine("3. Add TimePeriod to time.");
            Console.WriteLine("4. Subtract TimePeriod from time.");
            Console.WriteLine("Type a number if you want to perform an action, and when you want to retur to menu type 'return'.\n");
            Console.Write("Type here >> ");
        }

        public static Time ReadTimeFields()
        {
            Time time = new Time();
            try
            {
                Console.Write("Type hour: ");
                var hours = byte.Parse(Console.ReadLine());
                Console.Write("Type minute: ");
                var minutes = byte.Parse(Console.ReadLine());
                Console.Write("Type seconds: ");
                var seconds = byte.Parse(Console.ReadLine());
                Console.WriteLine();

                time = new Time(hours, minutes, seconds);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid time! Try Again.");
                Interface.TimeCommands();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid time values! Try Again.");
                Interface.TimeCommands();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid time record.");
                Interface.TimeCommands();
            }

            return time;
        }

        public static TimePeriod ReadTimePeriodFields()
        {
            TimePeriod time = new TimePeriod();
            try
            {
                Console.Write("Type hour: ");
                var hours = byte.Parse(Console.ReadLine());
                Console.Write("Type minute: ");
                var minutes = byte.Parse(Console.ReadLine());
                Console.Write("Type seconds: ");
                var seconds = byte.Parse(Console.ReadLine());
                Console.WriteLine();

                time = new TimePeriod(seconds, minutes, hours);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid time! Try Again.");
                Interface.TimeCommands();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid time values! Try Again.");
                Interface.TimeCommands();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid time record.");
                Interface.TimeCommands();
            }

            return time;
        }

        public static Time ReadStringTime()
        {
            Time time = new Time();
            try
            {
                Console.Write("Type string (hh:mm:ss): ");
                var s = Console.ReadLine();
                Console.WriteLine();

                time = new Time(s);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid time! Try Again.");
                Interface.TimeStringCommands();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid time values! Try Again.");
                Interface.TimeStringCommands();

            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid time record string");
                Interface.TimeStringCommands();

            }

            return time;
        }

        public static TimePeriod ReadStringTimePeriod()
        {
            TimePeriod time = new TimePeriod();
            try
            {
                Console.Write("Type string (hh:mm:ss): ");
                var s = Console.ReadLine();
                Console.WriteLine();

                time = new TimePeriod(s);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid time! Try Again.");
                Interface.TimeStringCommands();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid time values! Try Again.");
                Interface.TimeStringCommands();

            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid time record string");
                Interface.TimeStringCommands();

            }

            return time;
        }
    }
}
