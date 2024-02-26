using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangmanApp
{
    public class Words
    {
        public static (string word, string hint) GetRandomWordWithHintFromTextFile()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "words.txt");

            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"Words file not found: {filePath}");
                }

                List<(string word, string hint)> wordsWithHints = new List<(string word, string hint)>();
                foreach (string line in File.ReadAllLines(filePath))
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        wordsWithHints.Add((parts[0].Trim(), parts[1].Trim()));
                    }
                }

                Random random = new Random();
                int index = random.Next(wordsWithHints.Count);
                return wordsWithHints[index];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the words file: {ex.Message}");
                return ("", "");
            }
        }
    }
}
