namespace ConsoleCalculator
{
    class Program
    {
        private static List<string> history = new List<string>();

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
                Console.WriteLine("5. Show History");
                Console.WriteLine("6. Quit");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
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
                            PrintHistory();
                            break;
                        case 6:
                            quit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        static void PrintHistory()
        {
            bool showingHistory = true;

            while (showingHistory)
            {
                Console.WriteLine("History List:");
                foreach (string calculation in history)
                {
                    Console.WriteLine(calculation);
                }
                Console.WriteLine("1. Back to Menu");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice == 1)
                {
                    showingHistory = false;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }

        private static void PerformCalculation(Func<double, double, double> operation)
        {
            Console.WriteLine("Enter the first number: ");
            if (int.TryParse(Console.ReadLine(), out int num1))
            {
                double result = num1;

                bool continueCalculation = true;

                while (continueCalculation)
                {
                    Console.WriteLine("Select an option:");
                    Console.WriteLine("1. Add Number");
                    Console.WriteLine("2. Show Result");
                    Console.WriteLine("3. Back To Menu");

                    if (int.TryParse(Console.ReadLine(), out int option))
                    {
                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("Enter the next number: ");
                                if (int.TryParse(Console.ReadLine(), out int num2))
                                {
                                    num1 = (int)result;
                                    result = operation(num1, num2);
                                    AddToHistoryList(operation, num1, num2, result);
                                }
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
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
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

        static void AddToHistoryList(Func<double, double, double> operation, double num1, double num2, double result)
        {
            if (operation == Addition)
            {
                history.Add(num1 + "+" + num2 + "=" + result);
            }
            else if (operation == Substraction)
            {
                history.Add(num1 + "-" + num2 + "=" + result);
            }
            else if (operation == Multiplication)
            {
                history.Add(num1 + "x" + num2 + "=" + result);
            }
            else if (operation == Division)
            {
                history.Add(num1 + "/" + num2 + "=" + result);
            }

        }


    }

}
