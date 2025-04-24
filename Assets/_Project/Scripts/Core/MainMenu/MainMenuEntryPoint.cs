using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuEntryPoint : MonoBehaviour
{
    [SerializeField] private MainMenuView _mainMenuView;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _loadFirstSlotButton;
    [SerializeField] private Button _loadSecondSlotButton;
    [SerializeField] private Button _loadThirdSlotButton;
    [SerializeField] private GameObject _savesWindow;
    [SerializeField] private TMP_Text _firstLoadSlotText;
    [SerializeField] private TMP_Text _secondLoadSlotText;
    [SerializeField] private TMP_Text _thirdLoadSlotText;
    [SerializeField] private GameObject _buttons;

    private MainMenuModel _mainMenuModel;
    private MainMenuPresenter _mainMenuPresenter;

    private IStorage _storage;

    private void Awake()
    {
        InitializeServices();
        InitializeMVP();
    }

    private void InitializeServices()
    {
        _storage = new Storage();
    }

    private void InitializeMVP()
    {
        _mainMenuModel = new MainMenuModel();
        _mainMenuModel.Initialize();

        _mainMenuView.Initialize(_playButton, _exitButton, _backButton, _loadFirstSlotButton, _loadSecondSlotButton, _loadThirdSlotButton, _firstLoadSlotText, _secondLoadSlotText, _thirdLoadSlotText, _savesWindow, _buttons);

        _mainMenuPresenter = new MainMenuPresenter();
        _mainMenuPresenter.Initialize(_mainMenuModel, _mainMenuView, _storage);
    }

    private void OnDestroy()
    {
        _mainMenuPresenter.OnDestroy();
    }
}
