using System;
using System.ComponentModel;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] arg)
        {
            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("Choose a Calculation");
                Console.WriteLine("1. (+) Addition");
                Console.WriteLine("2. (-) Subtraction");
                Console.WriteLine("3. (x) Multiplication");
                Console.WriteLine("4. (/) Division");
                Console.WriteLine("5. Quit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        PerformCalculation(Addition);
                        break;
                    case 2:
                        PerformCalculation(Substraction);
                        break;
                    case 3:
                        PerformCalculation(Multiplication);
                        break;
                    case 4:
                        PerformCalculation(Division);
                        break;
                    case 5:
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void PerformCalculation(Func<double, double, double> operation)
        {
            Console.WriteLine("Enter the first number: ");
            double num1 = double.Parse(Console.ReadLine());
            double result = num1;
            bool continueCalculation = true;

            while (continueCalculation)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Add Number");
                Console.WriteLine("2. Show Result");
                Console.WriteLine("3. Back To Menu");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter the next number: ");
                        double num2 = double.Parse(Console.ReadLine());
                        result = operation(result, num2);
                        break;
                    case 2:
                        Console.WriteLine("Result: " + result);
                        break;
                    case 3:
                        continueCalculation = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static double Addition(double a, double b)
        {
            return a + b;
        }

        static double Substraction(double a, double b)
        {
            return a - b;
        }

        static double Multiplication(double a, double b)
        {
            return a * b;
        }

        static double Division(double a, double b)
        {
            return a / b;
        }
    }

}
