using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenuView : MonoBehaviour
{
    public event Action PlayButtonClicked;
    public event Action SettingsButtonClicked;
    public event Action ExitButtonClicked;
    public event Action BackButtonClicked;
    public event Action LoadFirstSlotButtonClicked;
    public event Action LoadSecondSlotButtonClicked;
    public event Action LoadThirdSlotButtonClicked;

    private Button _playButton;
    private Button _settingsButton;
    private Button _exitButton;
    private Button _backButton;
    private Button _loadFirstSlotButton;
    private Button _loadSecondSlotButton;
    private Button _loadThirdSlotButton;

    private GameObject _savesWindow;
    private GameObject _buttons;

    public void Initialize(Button playButton,
                           Button settingsButton,
                           Button exitButton,
                           Button backButton,
                           Button loadFirstSlotButton,
                           Button loadSecondSlotButton,
                           Button loadThirdSlotButton,
                           GameObject savesWindow,
                           GameObject buttons)
    {
        _playButton = playButton;
        _playButton.onClick.AddListener(OnPlayButtonClick);

        _settingsButton = settingsButton;
        _settingsButton.onClick.AddListener(OnSettingsButtonClick);

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

    private void OnPlayButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }

    private void OnSettingsButtonClick()
    {
        SettingsButtonClicked?.Invoke();
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
        _settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }
}
