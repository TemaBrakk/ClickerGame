using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;

public class MainMenuView : MonoBehaviour
{
    public event Action PlayButtonClicked;
    public event Action ExitButtonClicked;
    public event Action BackButtonClicked;
    public event Action LoadFirstSlotButtonClicked;
    public event Action LoadSecondSlotButtonClicked;
    public event Action LoadThirdSlotButtonClicked;

    private Button _playButton;
    private Button _exitButton;
    private Button _backButton;
    private Button _loadFirstSlotButton;
    private Button _loadSecondSlotButton;
    private Button _loadThirdSlotButton;

    private TMP_Text _firstLoadSlotText;
    private TMP_Text _secondLoadSlotText;
    private TMP_Text _thirdLoadSlotText;

    private GameObject _savesWindow;
    private GameObject _buttons;

    public void Initialize(Button playButton,
                           Button exitButton,
                           Button backButton,
                           Button loadFirstSlotButton,
                           Button loadSecondSlotButton,
                           Button loadThirdSlotButton,
                           TMP_Text firstLoadSlotText,
                           TMP_Text secondLoadSlotText,
                           TMP_Text thirdLoadSlotText,
                           GameObject savesWindow,
                           GameObject buttons)
    {
        _playButton = playButton;
        _playButton.onClick.AddListener(OnPlayButtonClick);

        _exitButton = exitButton;
        _exitButton.onClick.AddListener(OnExitButtonClick);

        _backButton = backButton;
        _backButton.onClick.AddListener(OnBackButtonClick);

        _loadFirstSlotButton = loadFirstSlotButton;
        _loadFirstSlotButton.onClick.AddListener(OnLoadFirstSlotButtonClick);

        _loadSecondSlotButton = loadSecondSlotButton;
        _loadSecondSlotButton.onClick.AddListener(OnLoadSecondSlotButtonClick);

        _loadThirdSlotButton = loadThirdSlotButton;
        _loadThirdSlotButton.onClick.AddListener(OnLoadThirdSlotButtonClick);

        _firstLoadSlotText = firstLoadSlotText;
        _secondLoadSlotText = secondLoadSlotText;
        _thirdLoadSlotText = thirdLoadSlotText;

        _savesWindow = savesWindow;
        _buttons = buttons;
    }

    public void ShowSavesWindow()
    {
        _savesWindow.transform.DOMoveX(Screen.width / 2f, 0.5f).SetEase(Ease.Linear);
        _buttons.transform.DOMoveX(-Screen.width / 2f, 0.5f).SetEase(Ease.Linear);
    }

    public void HideSavesWindow()
    {
        _savesWindow.transform.DOMoveX(Screen.width * 1.5f, 0.5f).SetEase(Ease.Linear);
        _buttons.transform.DOMoveX(Screen.width / 2f, 0.5f).SetEase(Ease.Linear);
    }

    public void UpdateFirstSaveSlotText(bool isEmpty, float coins = 0, float passiveIncome = 0)
    {
        if (isEmpty)
            _firstLoadSlotText.text = "Empty slot";
        else
            _firstLoadSlotText.text = $"Coins: {coins}\nPassive income: {passiveIncome}";
    }

    public void UpdateSecondSaveSlotText(bool isEmpty, float coins = 0, float passiveIncome = 0)
    {
        if (isEmpty)
            _secondLoadSlotText.text = "Empty slot";
        else
            _secondLoadSlotText.text = $"Coins: {coins}\nPassive income: {passiveIncome}";
    }

    public void UpdateThirdSaveSlotText(bool isEmpty, float coins = 0, float passiveIncome = 0)
    {
        if (isEmpty)
            _thirdLoadSlotText.text = "Empty slot";
        else
            _thirdLoadSlotText.text = $"Coins: {coins}\nPassive income: {passiveIncome}";
    }

    private void OnPlayButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }

    private void OnExitButtonClick()
    {
        ExitButtonClicked?.Invoke();
    }

    private void OnBackButtonClick()
    {
        BackButtonClicked?.Invoke();
    }

    private void OnLoadFirstSlotButtonClick()
    {
        LoadFirstSlotButtonClicked?.Invoke();
    }
    
    private void OnLoadSecondSlotButtonClick()
    {
        LoadSecondSlotButtonClicked?.Invoke();
    }
    
    private void OnLoadThirdSlotButtonClick()
    {
        LoadThirdSlotButtonClicked?.Invoke();
    }

    private void OnDestroy()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _backButton.onClick.RemoveListener(OnBackButtonClick);
        _loadFirstSlotButton.onClick.RemoveListener(OnLoadFirstSlotButtonClick);
        _loadSecondSlotButton.onClick.RemoveListener(OnLoadSecondSlotButtonClick);
        _loadThirdSlotButton.onClick.RemoveListener(OnLoadThirdSlotButtonClick);
    }
}
