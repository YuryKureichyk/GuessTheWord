using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GuessTheWord
{
    public class Game
    {
        private readonly Word _secretWord;
        private readonly int _attemptsMax;
        private int _errors;
        
        private readonly HashSet<char> _usedLetters = new HashSet<char>();
        private readonly HashSet<char> _guessedLetters = new HashSet<char>();

        private readonly ConsoleUI _ui = new ConsoleUI();

        public Game(Word word, int attemptsMax)
        {
            _secretWord = word;
            _attemptsMax = attemptsMax;
        }

        public void Run()
        {
            while (_errors < _attemptsMax && !IsWon())
            {
                Console.Clear();
                _ui.DrawGallows(_errors, _attemptsMax);
                char[] guessedArray = _usedLetters.Where(c => _secretWord.Contains(c)).ToArray();
                Console.WriteLine($"Word: {_secretWord.GetMask(guessedArray)}");
                Console.WriteLine($"Word: {_secretWord.GetMask(_guessedLetters.ToArray())}");
                _ui.ShowLeftAttempts(_attemptsMax - _errors);
                _ui.ShowUsedLetters(_usedLetters.ToArray());

                var letter = _ui.InputLetter();
                
                if (_usedLetters.Contains(letter))
                {
                    Console.WriteLine("This letter has already been used.");
                    Thread.Sleep(600);
                    continue;
                }

                _usedLetters.Add(letter);

                if (_secretWord.Contains(letter))
                {
                    _guessedLetters.Add(letter);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct letter");
                    Console.ResetColor();
                    Thread.Sleep(600);
                }
                else
                {
                    _errors++;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Wrong letter!");
                    Console.ResetColor();
                    Thread.Sleep(800);
                }
            }

            Console.Clear();
            _ui.ShowGameResult(IsWon());
            Console.Write("Word: ");
            _secretWord.DebugValue();
        }

        private bool IsWon()
        {
            return !_secretWord.GetMask(_guessedLetters.ToArray()).Contains("*");
        }
    }
}