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

    private Button _playButton;
    private Button _exitButton;
    private Button _backButton;

    private GameObject _savesWindow;
    private GameObject _buttons;

    public void Initialize(Button playButton,
                           Button exitButton,
                           Button backButton,
                           GameObject savesWindow,
                           GameObject buttons)
    {
        _playButton = playButton;
        _playButton.onClick.AddListener(OnPlayButtonClick);

        _exitButton = exitButton;
        _exitButton.onClick.AddListener(OnExitButtonClick);

        _backButton = backButton;
        _backButton.onClick.AddListener(OnBackButtonClick);

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

    private void OnExitButtonClick()
    {
        ExitButtonClicked?.Invoke();
    }

    private void OnBackButtonClick()
    {
        BackButtonClicked?.Invoke();
    }

    private void OnDestroy()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _backButton.onClick.RemoveListener(OnBackButtonClick);
    }
}
