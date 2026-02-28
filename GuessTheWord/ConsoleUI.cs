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

                Console.WriteLine("=== WELCOME TO THE GAME OF HANGMAN ===");
                Console.WriteLine("Select difficulty level:");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1 - EASY (10 attempts, short words)");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("2 - NORMAL (8 attempts, average words)");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("3 - HARD (6 attempts, long words)");

                Console.ResetColor();
                Console.WriteLine("Your choice:");
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
        

        public void ShowLeftAttempts(int leftAttempts)
        {
            Console.WriteLine($"You have attempts left.:{leftAttempts}");
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
        public void DrawGallows(int errors, int maxAttempts)
        {
            string[] stages = {
                @"
           -----

           |   |
               |

               |
               |
               |
        =========",
                @"
           -----

           |   |
           O   |

               |
               |
               |
        =========",
                @"
           -----

           |   |
           O   |

           |   |
               |

               |
        =========",
                @"
           -----
           |   |
           O   |
          /|   |

               |
               |
        =========",
                @"
           -----

           |   |
           O   |
          /|\  |

               |
               |
        =========", 
                @"
           -----

           |   |
           O   |
          /|\  |
          /    |

               |
        =========",
                @"
           -----
           |   |
           O   |
          /|\  |
          / \  |
               |
        ========="  
            };

            var index = (int)((double)errors / maxAttempts * (stages.Length - 1));
            
            if (index < 0) index = 0;
            if (index >= stages.Length) index = stages.Length - 1;
            
            if (errors >= maxAttempts) 
                index = stages.Length - 1;

            Console.WriteLine(stages[index]);
        }
    }
}