using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private Button _menuButton;
    [SerializeField] private GameObject _menu;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Image _image;
    private void Start()
    {
        _menu.SetActive(false);
    }

    private void OnEnable()
    {
        _image.fillAmount = 0;
        _menuButton.onClick.AddListener(OnMenuClick);
        _volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        _inputField.onValueChanged.AddListener(OnInputFieldChanged);
        _toggle.onValueChanged.AddListener(OnToggleChanged);
        
    }

    private void OnToggleChanged(bool value)
    {
        Debug.Log(value);
    }

    private void OnInputFieldChanged(string text)
    {
        Debug.Log(text);
    }


    private void OnDisable()
    {
        _volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
        
        _menuButton.onClick.RemoveListener(OnMenuClick);
    }

    private void OnMenuClick()
    {
        _menu.SetActive(!_menu.activeSelf);
    }
    private void OnVolumeChanged(float value)
    {
        Debug.Log(value);
    }
}
