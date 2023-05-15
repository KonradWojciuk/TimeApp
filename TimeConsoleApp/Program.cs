using TimeLibrary;

namespace TimeConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("#=================================#");
            Console.WriteLine("Welcome in TimeApp");
            Console.WriteLine("#=================================#");

            UserInterface.Interface.CommandLoop();

            Console.WriteLine("Thank you for using TimeApp");
        }
    }
}