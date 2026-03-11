using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameUIViev : MonoBehaviour
{
    
    [SerializeField] private TMP_InputField _inputLetter;
    [SerializeField] private Button _enterButton;
    [SerializeField] private TMP_Text _usedLetters;
    
    
    private char _letter;
    
    public event Action<char> LetterEntered;


    public void ShowUsedLetters(IEnumerable<char> usedLetters)
    {
        _usedLetters.text = string.Join(' ', usedLetters);
    }
    
    private void OnEnable()
    
    {
        
        _enterButton.onClick.AddListener(OnEnterClick);
        _inputLetter.onValueChanged.AddListener(OnLetterInput);
        
    }



    private void OnDisable()
    {
        _inputLetter.onValueChanged.RemoveListener(OnLetterInput);
        _enterButton.onClick.RemoveListener(OnEnterClick);
    }

    private void OnLetterInput(string letter)
    {
        
        if (ValidateLetter(letter))
        {
            string upperLetter = letter.ToUpper();
            _inputLetter.SetTextWithoutNotify(upperLetter);
            _letter = upperLetter[0];
            _enterButton.interactable = true;
            
        }
        else
        {
            _inputLetter.SetTextWithoutNotify(string.Empty);
            _letter = char.MinValue;
            _enterButton.interactable = false;
        }
    }

    private bool ValidateLetter(string letter)
    {
        if (string.IsNullOrEmpty(letter))
            return false;

        if (letter.Length != 1)
            return false;

        return char.IsLetter(letter[0]);
    }
    private void OnEnterClick()
    {
        LetterEntered?.Invoke(_letter);
        
    }
}
