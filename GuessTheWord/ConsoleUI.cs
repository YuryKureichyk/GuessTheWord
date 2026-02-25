using System;

namespace GuessTheWord
{
    public class ConsoleUI
    {
        public char InputLetter()
        {
            char letter;
            while (!char.TryParse(Console.ReadLine(), out letter) || !char.IsLetter(letter))
            {
                Console.Write("Input error. Please enter a letter. ");
            }
            return char.ToLower(letter);
        }

        public DifficultyType ChooseDifficulty()
        {
            while (true)
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
                        Console.WriteLine("Invalid choice. Enter 1, 2, or 3");
                        break;
                    
                }
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
            if (isWin)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You won!!!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"You lost");
            }
            Console.ResetColor();
        }
    }
}