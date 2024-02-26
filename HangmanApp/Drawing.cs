using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanApp
{
    public class Drawing
    {
        public static void DisplayWordWithDashes(string word, List<char> guessedLetters)
        {
            Console.Write("Word: ");
            foreach (char letter in word)
            {
                if (guessedLetters.Contains(letter))
                {
                    Console.Write(letter);
                }
                else
                {
                    Console.Write('-');
                }
                Console.Write(' ');
            }
            Console.WriteLine();
        }

        public static void DisplayHangman(int incorrectGuesses)
        {
            string[] hangmanParts = 
                {
            "  _____",
            " |     |",
            $" |     {(incorrectGuesses >= 1 ? "O" : "")}",
            $" |    {(incorrectGuesses >= 3 ? "/" : "")}{(incorrectGuesses >= 2 ? "|" : "")}{(incorrectGuesses >= 4 ? "\\" : "")}",
            $" |    {(incorrectGuesses >= 5 ? "/" : "")} {(incorrectGuesses >= 6 ? "\\" : "")}",
            " |",
            "_|_______"
            };

            foreach (string part in hangmanParts)
            {
                Console.WriteLine(part);
            }

        }
    }
}
