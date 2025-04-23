using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuEntryPoint : MonoBehaviour
{
    [SerializeField] private MainMenuView _mainMenuView;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _loadButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _loadFirstSlotButton;
    [SerializeField] private Button _loadSecondSlotButton;
    [SerializeField] private Button _loadThirdSlotButton;
    [SerializeField] private GameObject _savesWindow;
    [SerializeField] private GameObject _buttons;

    private MainMenuModel _mainMenuModel;
    private MainMenuPresenter _mainMenuPresenter;

    private SceneLoader _sceneLoader;
    private const string SCENE_LOADER_PATH = "Prefabs/SceneLoader";

    private void Awake()
    {
        InitializeServices();
        InitializeMVP();
    }

    private void InitializeServices()
    {
        SceneLoader prefab = Resources.Load<SceneLoader>(SCENE_LOADER_PATH);
        _sceneLoader = Instantiate(prefab);
    }

    private void InitializeMVP()
    {
        _mainMenuModel = new MainMenuModel();
        _mainMenuModel.Initialize();

        _mainMenuView.Initialize(_playButton, _loadButton, _exitButton, _backButton, _loadFirstSlotButton, _loadSecondSlotButton, _loadThirdSlotButton, _savesWindow, _buttons);

        _mainMenuPresenter = new MainMenuPresenter();
        _mainMenuPresenter.Initialize(_mainMenuModel, _mainMenuView, _sceneLoader);
    }

    private void OnDestroy()
    {
        _mainMenuPresenter.OnDestroy();
    }
}
