using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanApp
{
    public class Validations
    {
        public static bool IsValidInput(string input, out char guess)
        {
            guess = '\0'; // Initialize to prevent errors

            if (string.IsNullOrEmpty(input) || input.Length > 1 || !char.IsLetter(input[0]))
            {
                Console.WriteLine("Invalid input. Please enter a single letter (a-z).");
                return false;
            }

            guess = char.ToLower(input[0]);
            return true;
        }
    }
}
