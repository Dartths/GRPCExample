using System;
using System.Diagnostics;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This can be used as an interface to to a GRPC application");
            LifeCycle();
        }


        private static void LifeCycle()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Greet : 1");
            GetInstructionsForRequest(Console.ReadLine());

            LifeCycle();
        }


        private static Instructions GetInstructionsForRequest(string request)
        {
            int requestAsInt;
            int.TryParse(request, out requestAsInt);

            switch (requestAsInt)
            {
                case 1:
                    return new Instructions("Please say Hello");
                default:
                    return new Instructions("Please enter a valid value");
            }
        }
    }
}
