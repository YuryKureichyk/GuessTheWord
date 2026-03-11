
    using System.Collections.Generic;

    public class LetterAnalyzer
    {
        private HashSet<char> _usedLetters = new();
        private HashSet<char> _guessedLetters = new();
        
        public IEnumerable<char> UsedLetters => _usedLetters;
        
        public void AddLetter(char letter)
        {
            _usedLetters.Add(letter);
        }
        
    }
