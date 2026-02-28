using System;
using System.Collections.Generic;
using System.Linq;

namespace GuessTheWord
{
    public class WordBank
    {
        private List<string> _words;

        public WordBank()
        {
            _words = new List<string>()
            {
                "ide", "dog", "cat", "home","fish","tree","snow","moon",
                "cold", "unity","house","apple","river","smile", "laptop", "family", "teacher", 
                "computer","forest","flight","spirit","bright"
            };
        }

        public Word Generate(Difficulty difficulty)
        {
            var words = _words
                .Where(word => word.Length >= difficulty.MinWordLenght &&
                               word.Length <= difficulty.MaxWordLenght).ToArray();
            var random = new Random();
            var index = random.Next(words.Length);
            return new Word(words[index]);
        }
    }
}