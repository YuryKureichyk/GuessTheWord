using System;

namespace GuessTheWord
{
    public class ConsoleUI
    {
        public char InputLetter()
        {
            var result = Console.ReadLine();
            return result[0];
        }

        public DifficultyType ChooseDifficulty()
        {
            Console.WriteLine("Choose difficulty:\n" +
                              "1 - easy\n" +
                              "2 - normal\n" +
                              "3 - hard");
            var result = Console.ReadLine();

            switch (result)
            {
                case "1":
                    return DifficultyType.Easy;
                case "2":
                    return DifficultyType.Normal;
                case "3":
                    return DifficultyType.Hard;
                default:
                    return DifficultyType.Easy;
            }
        }

        public void ShowUsedLetters(char[] letters)
        {
            Console.WriteLine("Used letters:");
            foreach (char letter in letters)
            {
                Console.Write($"{letter} ");
            }

            Console.WriteLine();
        }

        public void ShowWords(string[] word)
        {
            Console.WriteLine($"Words:{word}");
        }

        public void ShowLeftAttempts(int leftAttempts)
        {
            Console.WriteLine($"Left attempts:{leftAttempts}");
        }

        public void ShowGameResult(bool isWin)
        {
            Console.WriteLine(isWin ? "You won!" : "You lost!");
        }
    }
}