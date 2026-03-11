
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public class GameController  : MonoBehaviour
    
    
    {
        [SerializeField] private GameUIViev _gameUI;
        
        private LetterAnalyzer _letterAnalyzer = new();
        


        private void OnEnable()
        {
            _gameUI.LetterEntered += OnLetterEntered;
        }

        private void OnDisable()
        {
            _gameUI.LetterEntered -= OnLetterEntered; 
        }

        private void OnLetterEntered(char letter)
        {
            AddLetter(letter);
        }
        private void AddLetter(char letter)
        {
            _letterAnalyzer.AddLetter(letter);

            _gameUI.ShowUsedLetters(_letterAnalyzer.UsedLetters);
        }
    }
