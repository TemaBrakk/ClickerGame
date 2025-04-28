using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainMenuPresenter
{
    private MainMenuModel _mainMenuModel;
    private MainMenuView _mainMenuView;

    public void Initialize(MainMenuModel mainMenuModel,
                           MainMenuView mainMenuView)
    {
        _mainMenuModel = mainMenuModel;
        _mainMenuView = mainMenuView;

        Subscribe();
        PrepareUI();
    }

    private void Subscribe()
    {
        _mainMenuView.PlayButtonClicked += OnPlayButtonClick;
        _mainMenuView.ExitButtonClicked += OnExitButtonClick;
        _mainMenuView.BackButtonClicked += OnBackButtonClick;
    }

    private void PrepareUI()
    {
        _mainMenuView.ResetSavesWindowPosition();
    }

    private void OnPlayButtonClick()
    {
        _mainMenuView.ShowSavesWindow();
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

    public void OnDestroy()
    {
        Unsubscribe();
    }

    private void Unsubscribe()
    {
        _mainMenuView.PlayButtonClicked -= OnPlayButtonClick;
        _mainMenuView.ExitButtonClicked -= OnExitButtonClick;
        _mainMenuView.BackButtonClicked -= OnBackButtonClick;
    }
}
