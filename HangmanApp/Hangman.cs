using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanApp
{
    public class Hangman
    {
        private static readonly int MaxGuesses = 6;

        private static string? chosenWord;
        private static List<char>? guessedLetters;
        private static int remainingGuesses;
        private static string? hint;

        public static void StartGame()
        {
            (chosenWord, hint) = Words.GetRandomWordWithHintFromTextFile();
            guessedLetters = new List<char>();
            remainingGuesses = MaxGuesses;

            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine($"You have {MaxGuesses} guesses to guess the word.");
            Console.WriteLine("Hint: " + hint);
            Drawing.DisplayWordWithDashes(chosenWord, guessedLetters);
            Drawing.DisplayHangman(MaxGuesses - remainingGuesses);
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");

            while (remainingGuesses > 0 && !IsWordGuessed())
            {
                GetAndProcessGuess();
            }

            EndGame();
        }



        private static void GetAndProcessGuess()
        {
            char guess;
            string? input;
            do
            {
                Console.Write("Guess a letter (a-z): ");
                input = Console.ReadLine()?.ToLower();
            } while (!Validations.IsValidInput(input, out guess));

            if (guessedLetters.Contains(guess))
            {
                Console.WriteLine("You already guessed that letter.");
            }
            else
            {
                guessedLetters.Add(guess);
                if (chosenWord.Contains(guess))
                {
                    Console.WriteLine("Good guess!");
                }
                else
                {
                    Console.WriteLine("Incorrect guess.");
                    remainingGuesses--;
                    Console.WriteLine($"You have {remainingGuesses} guesses left.");
                }
            }

            Drawing.DisplayWordWithDashes(chosenWord, guessedLetters);
            Drawing.DisplayHangman(MaxGuesses - remainingGuesses);
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
        }



        private static bool IsWordGuessed()
        {
            return chosenWord.All(letter => guessedLetters.Contains(letter));
        }

        private static void EndGame()
        {
            if (IsWordGuessed())
            {
                Console.WriteLine("Congratulations! You guessed the word.");
            }
            else
            {
                Console.WriteLine("You ran out of guesses. The word was: {0}", chosenWord);
            }

            Console.WriteLine("Thanks for playing!");
        }
    }
}
