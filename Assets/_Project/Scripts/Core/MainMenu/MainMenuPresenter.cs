using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPresenter
{
    private MainMenuModel _mainMenuModel;
    private MainMenuView _mainMenuView;

    private SceneLoader _sceneLoader;

    public void Initialize(MainMenuModel mainMenuModel,
                           MainMenuView mainMenuView,
                           SceneLoader sceneLoader)
    {
        _mainMenuModel = mainMenuModel;
        _mainMenuView = mainMenuView;

        _sceneLoader = sceneLoader;

        SubscribeToView();
    }

    private void SubscribeToView()
    {
        _mainMenuView.PlayButtonClicked += OnPlayButtonClick;
        _mainMenuView.SettingsButtonClicked += OnSettingsButtonClick;
        _mainMenuView.ExitButtonClicked += OnExitButtonClick;
        _mainMenuView.BackButtonClicked += OnBackButtonClick;
        _mainMenuView.LoadFirstSlotButtonClicked += OnLoadFirstSlotButtonClick;
        _mainMenuView.LoadSecondSlotButtonClicked += OnLoadSecondSlotButtonClick;
        _mainMenuView.LoadThirdSlotButtonClicked += OnLoadThirdSlotButtonClick;
    }

    private void OnPlayButtonClick()
    {
        _mainMenuView.ShowSavesWindow();
    }

    private void OnSettingsButtonClick()
    {

    }

    private void OnExitButtonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void OnBackButtonClick()
    {
        _mainMenuView.HideSavesWindow();
    }

    private void OnLoadFirstSlotButtonClick()
    {
        _sceneLoader.LoadGameScene();
    }

    private void OnLoadSecondSlotButtonClick()
    {
        _sceneLoader.LoadGameScene();
    }

    private void OnLoadThirdSlotButtonClick()
    {
        _sceneLoader.LoadGameScene();
    }

    public void OnDestroy()
    {
        _mainMenuView.PlayButtonClicked -= OnPlayButtonClick;
        _mainMenuView.SettingsButtonClicked -= OnSettingsButtonClick;
        _mainMenuView.ExitButtonClicked -= OnExitButtonClick;
        _mainMenuView.BackButtonClicked -= OnBackButtonClick;
        _mainMenuView.LoadFirstSlotButtonClicked -= OnLoadFirstSlotButtonClick;
        _mainMenuView.LoadSecondSlotButtonClicked -= OnLoadSecondSlotButtonClick;
        _mainMenuView.LoadThirdSlotButtonClicked -= OnLoadThirdSlotButtonClick;
    }
}
