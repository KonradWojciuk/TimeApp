using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLibrary;

namespace TimeConsoleApp.UserInterface
{
    public class Interface
    {
        public static bool Quit = false;
        public static void CommandLoop()
        {
            while (!Quit)
            {
                Console.WriteLine();

                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Enter the time in the appropriate fields.");
                Console.WriteLine("2. Enter the time as string.");
                Console.WriteLine("3. Enter the timePeriod as a number of seconds.");
                Console.WriteLine("4. Enter the timePeriod in the appropriate fields.");
                Console.WriteLine("5. Enter the timePeriod as the difference of two times.");
                Console.WriteLine("6. Enter the timePeriod as string.");
                Console.WriteLine("Type a number if you want to perform an action, and when you want to exit type 'quit'.\n");
                Console.Write("Type here >> ");

                var command = Console.ReadLine();
                CommandRoute(command);
            }
        }

        public static void CommandRoute(string command)
        {
            if (command == "1")
                TimeCommands();
            else if (command == "2")
                TimeStringCommands();
            else if (command == "3")
                TimePeriodSecondLoop();
            else if (command == "4")
                TimePeriodFieldsLoop();
            else if (command == "5")
                TimePeriodTwoTimesDifferenceLoop();
            else if (command == "6")
                TimePeriodStringLoop();
            else if (command == "quit")
                Quit = true;
            else
                Console.WriteLine("Unknow command {0}. Try again.\n", command);

        }

        public static void TimeCommands()
        {
            Console.WriteLine();

            Console.WriteLine("Type your time below:\n");
            Time time = HelpMethods.ReadTimeFields();

            bool leav = false;

            while (!leav)
            {
                HelpMethods.ShowMenu();

                var command = Console.ReadLine();
                Console.WriteLine();

                if (command == "1")
                    Console.WriteLine(time.ToString() + "\n");
                else if (command == "2")
                {
                    Console.WriteLine("Type your time below: \n");
                    Time time1 = HelpMethods.ReadTimeFields();

                    Console.WriteLine("Type operator you want to use?\n");
                    Console.Write("Type here >> ");
                    var userOperator = Console.ReadLine();
                    Console.WriteLine();

                    if (userOperator == "==")
                        OperatorMethods.EqualsTime(time, time1);
                    else if (userOperator == "!=")
                        OperatorMethods.NotEqualsTime(time, time1);
                    else if (userOperator == "<")
                        OperatorMethods.LowerTime(time, time1);
                    else if (userOperator == "<=")
                        OperatorMethods.LowerOrEqualsTime(time, time1);
                    else if (userOperator == ">")
                        OperatorMethods.BiggerTime(time, time1);
                    else if (userOperator == ">=")
                        OperatorMethods.BiggerOrEqualsTime(time, time1);
                    else
                        Console.WriteLine("Unknow command. Try again");
                }
                else if (command == "3")
                {
                    Console.WriteLine("Type your time below: \n");
                    TimePeriod time1 = HelpMethods.ReadTimePeriodFields();

                    var result = time + time1;

                    Console.WriteLine("Here is the time after adding another: " + result.ToString() + "\n");
                }
                else if (command == "4")
                {
                    Console.WriteLine("Type your time below: \n");
                    TimePeriod time1 = HelpMethods.ReadTimePeriodFields();

                    try
                    {
                        var result = time - time1;
                        Console.WriteLine("Here is the time after subtracting another: " + result.ToString() + "\n");
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("You can't subtract more time from less time ");
                    }
                }
                else if (command == "return")
                    leav = true;
                else
                    Console.WriteLine("Unknow command {0}. Try again.\n", command);
            }
        }

        public static void TimeStringCommands()
        {
            Console.WriteLine();

            bool leav = false;

            Console.WriteLine("Type your time below:\n");
            Time time = HelpMethods.ReadStringTime();

            while (!leav)
            {
                HelpMethods.ShowMenu();

                var command = Console.ReadLine();
                Console.WriteLine();

                if (command == "1")
                    Console.WriteLine(time.ToString() + "\n");
                else if (command == "2")
                {
                    Console.WriteLine("Type your time below: \n");
                    Time time1 = HelpMethods.ReadStringTime();

                    Console.WriteLine("Type operator you want to use?\n");
                    Console.Write("Type here >> ");
                    var userOperator = Console.ReadLine();
                    Console.WriteLine();

                    if (userOperator == "==")
                        OperatorMethods.EqualsTime(time, time1);
                    else if (userOperator == "!=")
                        OperatorMethods.NotEqualsTime(time, time1);
                    else if (userOperator == "<")
                        OperatorMethods.LowerTime(time, time1);
                    else if (userOperator == "<=")
                        OperatorMethods.LowerOrEqualsTime(time, time1);
                    else if (userOperator == ">")
                        OperatorMethods.BiggerTime(time, time1);
                    else if (userOperator == ">=")
                        OperatorMethods.BiggerOrEqualsTime(time, time1);
                    else
                        Console.WriteLine("Unknow command. Try again");
                }
                else if (command == "3")
                {
                    Console.WriteLine("Type your time below: \n");
                    TimePeriod time1 = HelpMethods.ReadStringTimePeriod();

                    var result = time + time1;

                    Console.WriteLine("Here is the time after adding another: " + result.ToString() + "\n");
                }
                else if (command == "4")
                {
                    Console.WriteLine("Type your time below: \n");
                    TimePeriod time1 = HelpMethods.ReadTimePeriodFields();

                    try
                    {
                        var result = time - time1;
                        Console.WriteLine("Here is the time after subtracting another: " + result.ToString() + "\n");
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("You can't subtract more time from less time ");
                    }
                }
                else if (command == "return")
                    leav = true;
                else
                    Console.WriteLine("Unknow command {0}. Try again.\n", command);
            }
        }

        public static void TimePeriodSecondLoop()
        {
            Console.WriteLine();
            TimePeriod time = new TimePeriod();

            try
            {
                Console.Write("Enter the number of seconds of your time: ");
                long seconds = long.Parse(Console.ReadLine());
                time = new TimePeriod(seconds);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Seconds cannot be negative.");
                TimePeriodSecondLoop();
            }

            bool leav = false;

            while (!leav)
            {
                HelpMethods.ShowMenu();

                var command = Console.ReadLine();
                Console.WriteLine();

                if (command == "1")
                    Console.WriteLine(time.ToString() + "\n");
                else if (command == "2")
                {
                    Console.WriteLine("Type your time below: \n");
                    TimePeriod time1 = new TimePeriod();

                    try
                    {
                        Console.Write("Enter the number of seconds of your time: ");
                        long seconds = long.Parse(Console.ReadLine());
                        time = new TimePeriod(seconds);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Seconds cannot be negative.");
                    }

                    Console.WriteLine("Type operator you want to use?\n");
                    Console.Write("Type here >> ");
                    var userOperator = Console.ReadLine();
                    Console.WriteLine();

                    if (userOperator == "==")
                        OperatorMethods.EqualsTimePeriod(time, time1);
                    else if (userOperator == "!=")
                        OperatorMethods.EqualsTimePeriod(time, time1);
                    else if (userOperator == "<")
                        OperatorMethods.LowerTimePeriod(time, time1);
                    else if (userOperator == "<=")
                        OperatorMethods.LowerOrEqualsTimePeriod(time, time1);
                    else if (userOperator == ">")
                        OperatorMethods.BiggerTimePeriod(time, time1);
                    else if (userOperator == ">=")
                        OperatorMethods.BiggerOrEqualsTimePeriod(time, time1);
                    else
                        Console.WriteLine("Unknow command. Try again");
                }
                else if (command == "3")
                {
                    Console.WriteLine("Type your time below: \n");
                    TimePeriod time1 = new TimePeriod();

                    try
                    {
                        Console.Write("Enter the number of seconds of your time: ");
                        long seconds = long.Parse(Console.ReadLine());
                        time = new TimePeriod(seconds);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Seconds cannot be negative.");
                    }

                    var result = time + time1;

                    Console.WriteLine("Here is the time after adding another: " + result.ToString() + "\n");
                }
                else if (command == "4")
                {
                    Console.WriteLine("Type your time below: \n");
                    TimePeriod time1 = new TimePeriod();

                    try
                    {
                        Console.Write("Enter the number of seconds of your time: ");
                        long seconds = long.Parse(Console.ReadLine());
                        time = new TimePeriod(seconds);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Seconds cannot be negative.");
                    }

                    try
                    {
                        var result = time - time1;
                        Console.WriteLine("Here is the time after subtracting another: " + result.ToString() + "\n");
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("You can't subtract more time from less time ");
                    }
                }
                else if (command == "return")
                    leav = true;
                else
                    Console.WriteLine("Unknow command {0}. Try again.\n", command);
            }
        }

        public static void TimePeriodFieldsLoop()
        {
            Console.WriteLine();
            TimePeriod time = HelpMethods.ReadTimePeriodFields();

            bool leav = false;

            while (!leav)
            {
                HelpMethods.ShowMenu();

                var command = Console.ReadLine();
                Console.WriteLine();

                if (command == "1")
                    Console.WriteLine(time.ToString() + "\n");
                else if (command == "2")
                {
                    Console.WriteLine("Type your time below: \n");
                    TimePeriod time1 = HelpMethods.ReadTimePeriodFields();

                    try
                    {
                        Console.Write("Enter the number of seconds of your time: ");
                        long seconds = long.Parse(Console.ReadLine());
                        time = new TimePeriod(seconds);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Seconds cannot be negative.");
                    }

                    Console.WriteLine("Type operator you want to use?\n");
                    Console.Write("Type here >> ");
                    var userOperator = Console.ReadLine();
                    Console.WriteLine();

                    if (userOperator == "==")
                        OperatorMethods.EqualsTimePeriod(time, time1);
                    else if (userOperator == "!=")
                        OperatorMethods.EqualsTimePeriod(time, time1);
                    else if (userOperator == "<")
                        OperatorMethods.LowerTimePeriod(time, time1);
                    else if (userOperator == "<=")
                        OperatorMethods.LowerOrEqualsTimePeriod(time, time1);
                    else if (userOperator == ">")
                        OperatorMethods.BiggerTimePeriod(time, time1);
                    else if (userOperator == ">=")
                        OperatorMethods.BiggerOrEqualsTimePeriod(time, time1);
                    else
                        Console.WriteLine("Unknow command. Try again");
                }
                else if (command == "3")
                {
                    Console.WriteLine("Type your time below: \n");
                    TimePeriod time1 = HelpMethods.ReadTimePeriodFields();

                    var result = time + time1;

                    Console.WriteLine("Here is the time after adding another: " + result.ToString() + "\n");
                }
                else if (command == "4")
                {
                    Console.WriteLine("Type your time below: \n");
                    TimePeriod time1 = HelpMethods.ReadTimePeriodFields();

                    try
                    {
                        var result = time - time1;
                        Console.WriteLine("Here is the time after subtracting another: " + result.ToString() + "\n");
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("You can't subtract more time from less time ");
                    }
                }
                else if (command == "return")
                    leav = true;
                else
                    Console.WriteLine("Unknow command {0}. Try again.\n", command);
            }
        }

        public static void TimePeriodTwoTimesDifferenceLoop()
        {
            Console.WriteLine();
            Time timeValue = HelpMethods.ReadStringTime();

            Console.WriteLine("Enter second time \n");

            Time timeValue1 = HelpMethods.ReadStringTime();

            TimePeriod time = new TimePeriod();

            try
            {
                time = new TimePeriod(timeValue, timeValue1);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("End time cannot be earlier than start time.");
                TimePeriodTwoTimesDifferenceLoop();
            }

            bool leav = false;

            while (!leav)
            {
                HelpMethods.ShowMenu();

                var command = Console.ReadLine();
                Console.WriteLine();

                if (command == "1")
                    Console.WriteLine(time.ToString() + "\n");
                else if (command == "2")
                {
                    Console.WriteLine("Type your time below: \n");
                    TimePeriod time1 = HelpMethods.ReadTimePeriodFields();

                    try
                    {
                        Console.Write("Enter the number of seconds of your time: ");
                        long seconds = long.Parse(Console.ReadLine());
                        time = new TimePeriod(seconds);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Seconds cannot be negative.");
                    }

                    Console.WriteLine("Type operator you want to use?\n");
                    Console.Write("Type here >> ");
                    var userOperator = Console.ReadLine();
                    Console.WriteLine();

                    if (userOperator == "==")
                        OperatorMethods.EqualsTimePeriod(time, time1);
                    else if (userOperator == "!=")
                        OperatorMethods.EqualsTimePeriod(time, time1);
                    else if (userOperator == "<")
                        OperatorMethods.LowerTimePeriod(time, time1);
                    else if (userOperator == "<=")
                        OperatorMethods.LowerOrEqualsTimePeriod(time, time1);
                    else if (userOperator == ">")
                        OperatorMethods.BiggerTimePeriod(time, time1);
                    else if (userOperator == ">=")
                        OperatorMethods.BiggerOrEqualsTimePeriod(time, time1);
                    else
                        Console.WriteLine("Unknow command. Try again");
                }
                else if (command == "3")
                {
                    Console.WriteLine("Type your time below: \n");
                    TimePeriod time1 = HelpMethods.ReadTimePeriodFields();

                    var result = time + time1;

                    Console.WriteLine("Here is the time after adding another: " + result.ToString() + "\n");
                }
                else if (command == "4")
                {
                    Console.WriteLine("Type your time below: \n");
                    TimePeriod time1 = HelpMethods.ReadTimePeriodFields();

                    try
                    {
                        var result = time - time1;
                        Console.WriteLine("Here is the time after subtracting another: " + result.ToString() + "\n");
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("You can't subtract more time from less time ");
                    }
                }
                else if (command == "return")
                    leav = true;
                else
                    Console.WriteLine("Unknow command {0}. Try again.\n", command);
            }
        }

        public static void TimePeriodStringLoop()
        {
            Console.WriteLine();

            Console.WriteLine("Type your time below:\n");
            TimePeriod time = HelpMethods.ReadStringTimePeriod();

            bool leav = false;

            while (!leav)
            {
                HelpMethods.ShowMenu();

                var command = Console.ReadLine();
                Console.WriteLine();

                if (command == "1")
                    Console.WriteLine(time.ToString() + "\n");
                else if (command == "2")
                {
                    Console.WriteLine("Type your time below: \n");
                    TimePeriod time1 = HelpMethods.ReadStringTimePeriod();

                    Console.WriteLine("Type operator you want to use?\n");
                    Console.Write("Type here >> ");
                    var userOperator = Console.ReadLine();
                    Console.WriteLine();

                    if (userOperator == "==")
                        OperatorMethods.EqualsTimePeriod(time, time1);
                    else if (userOperator == "!=")
                        OperatorMethods.NotEqualsTimePeriod(time, time1);
                    else if (userOperator == "<")
                        OperatorMethods.LowerTimePeriod(time, time1);
                    else if (userOperator == "<=")
                        OperatorMethods.LowerOrEqualsTimePeriod(time, time1);
                    else if (userOperator == ">")
                        OperatorMethods.BiggerTimePeriod(time, time1);
                    else if (userOperator == ">=")
                        OperatorMethods.BiggerOrEqualsTimePeriod(time, time1);
                    else
                        Console.WriteLine("Unknow command. Try again");
                }
                else if (command == "3")
                {
                    Console.WriteLine("Type your time below: \n");
                    TimePeriod time1 = HelpMethods.ReadTimePeriodFields();

                    var result = time + time1;

                    Console.WriteLine("Here is the time after adding another: " + result.ToString() + "\n");
                }
                else if (command == "4")
                {
                    Console.WriteLine("Type your time below: \n");
                    TimePeriod time1 = HelpMethods.ReadTimePeriodFields();

                    try
                    {
                        var result = time - time1;
                        Console.WriteLine("Here is the time after subtracting another: " + result.ToString() + "\n");
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("You can't subtract more time from less time ");
                    }
                }
                else if (command == "return")
                    leav = true;
                else
                    Console.WriteLine("Unknow command {0}. Try again.\n", command);
            }
        }
    }
}
