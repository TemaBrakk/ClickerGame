using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuEntryPoint : MonoBehaviour
{
    [Header("View")]
    [SerializeField] private MainMenuView _mainMenuView;
    [SerializeField] private SaveView _saveView;

    [Header("Main Menu Buttons")]
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _backButton;

    [Header("Save Buttons")]
    [SerializeField] private Button _loadFirstSlotButton;
    [SerializeField] private Button _loadSecondSlotButton;
    [SerializeField] private Button _loadThirdSlotButton;

    [Header("Text")]
    [SerializeField] private TMP_Text _firstLoadSlotText;
    [SerializeField] private TMP_Text _secondLoadSlotText;
    [SerializeField] private TMP_Text _thirdLoadSlotText;

    [Header("Windows")]
    [SerializeField] private GameObject _savesWindow;
    [SerializeField] private GameObject _buttons;

    private MainMenuModel _mainMenuModel;
    private MainMenuPresenter _mainMenuPresenter;

    private SaveModel _saveModel;
    private SavePresenter _savePresenter;

    private IStorage _storage;

    private void Awake()
    {
        InitializeServices();

        InitializeMainMenuMVP();
        InitializeSaveMVP();
    }

    private void InitializeServices()
    {
        _storage = new Storage();
    }

    private void InitializeMainMenuMVP()
    {
        _mainMenuModel = new MainMenuModel();
        _mainMenuPresenter = new MainMenuPresenter();
        
        _mainMenuModel.Initialize();
        _mainMenuView.Initialize(_playButton, _exitButton, _backButton, _savesWindow, _buttons);
        _mainMenuPresenter.Initialize(_mainMenuModel, _mainMenuView);
    }

    private void InitializeSaveMVP()
    {
        _saveModel = new SaveModel();
        _savePresenter = new SavePresenter();
        
        _saveModel.Initialize();
        _saveView.Initialize(_loadFirstSlotButton, _loadSecondSlotButton, _loadThirdSlotButton, _firstLoadSlotText, _secondLoadSlotText, _thirdLoadSlotText);
        _savePresenter.Initialize(_saveModel, _saveView, _storage);
    }

    private void OnDestroy()
    {
        _mainMenuPresenter.OnDestroy();
        _savePresenter.OnDestroy();
    }
}
