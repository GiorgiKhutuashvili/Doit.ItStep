namespace CalculatorApp
{
    public class CalculatorValidations
    {
        public static double ValidateDoubleInput()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                double num;

                if (!double.TryParse(input, out num))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                else
                {
                    return num;
                }
            }
        }

        public static bool IsOperationValid(char operation)
        {
            return operation == '+' || operation == '-' || operation == '*' || operation == '/' || operation == 'e';
        }
    }
}
