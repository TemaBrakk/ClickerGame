using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainMenuPresenter
{
    private MainMenuModel _mainMenuModel;
    private MainMenuView _mainMenuView;

    private IStorage _storage;

    private const string SAVE_FILE_NAME = "Save";

    public void Initialize(MainMenuModel mainMenuModel,
                           MainMenuView mainMenuView,
                           IStorage storage)
    {
        _mainMenuModel = mainMenuModel;
        _mainMenuView = mainMenuView;

        _storage = storage;

        SubscribeToView();
        UpdateSaveSlotsText();
    }

    private void SubscribeToView()
    {
        _mainMenuView.PlayButtonClicked += OnPlayButtonClick;
        _mainMenuView.ExitButtonClicked += OnExitButtonClick;
        _mainMenuView.BackButtonClicked += OnBackButtonClick;
        _mainMenuView.LoadFirstSlotButtonClicked += OnLoadFirstSlotButtonClick;
        _mainMenuView.LoadSecondSlotButtonClicked += OnLoadSecondSlotButtonClick;
        _mainMenuView.LoadThirdSlotButtonClicked += OnLoadThirdSlotButtonClick;
    }

    private void UpdateSaveSlotsText()
    {
        if (!_storage.IsFileExists(SAVE_FILE_NAME + "1"))
        {
            _mainMenuView.UpdateFirstSaveSlotText(true);
        }
        else
        {
            GameSaveData data = _storage.Load<GameSaveData>(SAVE_FILE_NAME + "1");
            _mainMenuView.UpdateFirstSaveSlotText(false, data.Coins, data.PassiveIncome);
        }

        if (!_storage.IsFileExists(SAVE_FILE_NAME + "2"))
        {
            _mainMenuView.UpdateSecondSaveSlotText(true);
        }
        else
        {
            GameSaveData data = _storage.Load<GameSaveData>(SAVE_FILE_NAME + "2");
            _mainMenuView.UpdateSecondSaveSlotText(false, data.Coins, data.PassiveIncome);
        }

        if (!_storage.IsFileExists(SAVE_FILE_NAME + "3"))
        {
            _mainMenuView.UpdateThirdSaveSlotText(true);
        }
        else
        {
            GameSaveData data = _storage.Load<GameSaveData>(SAVE_FILE_NAME + "3");
            _mainMenuView.UpdateThirdSaveSlotText(false, data.Coins, data.PassiveIncome);
        }
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

    private void OnLoadFirstSlotButtonClick()
    {
        HandleSaves("1");
        SceneLoader.Instance.LoadGameScene();
    }

    private void OnLoadSecondSlotButtonClick()
    {
        HandleSaves("2");
        SceneLoader.Instance.LoadGameScene();
    }

    private void OnLoadThirdSlotButtonClick()
    {
        HandleSaves("3");
        SceneLoader.Instance.LoadGameScene();
    }

    private void HandleSaves(string slotNumber)
    {
        string key = SAVE_FILE_NAME + slotNumber;

        if (!_storage.IsFileExists(key))
            _storage.Save(key, new GameSaveData(0f, 1f, 0f, 1f));

        GameSaveData saveData = _storage.Load<GameSaveData>(key);
        _storage.Save(SAVE_FILE_NAME, saveData);
    }

    public void OnDestroy()
    {
        _mainMenuView.PlayButtonClicked -= OnPlayButtonClick;
        _mainMenuView.ExitButtonClicked -= OnExitButtonClick;
        _mainMenuView.BackButtonClicked -= OnBackButtonClick;
        _mainMenuView.LoadFirstSlotButtonClicked -= OnLoadFirstSlotButtonClick;
        _mainMenuView.LoadSecondSlotButtonClicked -= OnLoadSecondSlotButtonClick;
        _mainMenuView.LoadThirdSlotButtonClicked -= OnLoadThirdSlotButtonClick;
    }
}
