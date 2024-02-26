namespace CalculatorApp
{
    public class Calculator
    {
        public static void ExecuteCalculator()
        {
            Console.WriteLine("Welcome to the C# Calculator App!");

            while (true)
            {
                Console.WriteLine("\nChoose an operation:");
                Console.WriteLine("1. Add (+)");
                Console.WriteLine("2. Subtract (-)");
                Console.WriteLine("3. Multiply (*)");
                Console.WriteLine("4. Divide (/)");
                Console.WriteLine("5. To exit the application, press e");
                Console.WriteLine();

                string? input = Console.ReadLine();
                char operation;

                if (!char.TryParse(input, out operation))
                {
                    Console.WriteLine("Invalid input. Please enter a symbol (+, -, *, /) or e to exit.");
                    continue;
                }

                if (!CalculatorValidations.IsOperationValid(operation))
                {
                    Console.WriteLine("Invalid operation. Please choose a valid operation (+, -, *, /) or e to exit.");
                    continue;
                }

                if (operation == 'e')
                {
                    break;
                }

                try
                {
                    Console.WriteLine("Enter the first number:");
                    double num1 = CalculatorValidations.ValidateDoubleInput();

                    Console.WriteLine("Enter the second number:");
                    double num2 = CalculatorValidations.ValidateDoubleInput();

                    double result;

                    switch (operation)
                    {
                        case '+':
                            result = num1 + num2;
                            break;
                        case '-':
                            result = num1 - num2;
                            break;
                        case '*':
                            result = num1 * num2;
                            break;
                        case '/':
                            if (num2 == 0)
                            {
                                throw new DivideByZeroException("Cannot divide by zero.");
                            }
                            result = num1 / num2;
                            break;
                        default:
                            throw new InvalidOperationException("Unknown operation.");
                    }

                    Console.WriteLine("Result: {0}", result);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Error: {0}. Please try again.", ex.Message);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("Error: {0}. Please enter a non-zero divisor.", ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occurred: {0}. Please try again.", ex.Message);
                }
            }

            Console.WriteLine("Goodbye! Press any key to exit...");
            Console.ReadKey();
        }
    }
}
