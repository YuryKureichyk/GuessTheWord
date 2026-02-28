using System;

namespace GuessTheWord
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var ui = new ConsoleUI();
            var bank = new WordBank();
            
            var type = ui.ChooseDifficulty();
            var difficulty = new Difficulty(type);
            var secretWord = bank.Generate(difficulty);
            
            var game = new Game(secretWord, difficulty.Attempt);
            game.Run();
            Console.WriteLine("Exiting...");
            Console.ReadKey();

        }
    }
}