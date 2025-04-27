using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class GameView : MonoBehaviour
{
    public event Action CharacterClicked;
    public event Action SaveButtonClicked;
    public event Action ShopButtonClicked;
    public event Action ExitButtonClicked;

    private Button _saveButton;
    private Button _shopButton;
    private Button _exitButton;

    private GameObject _savesWindow;
    private GameObject _shopWindow;

    private TMP_Text _coinsText;

    private InputReader _inputReader;

    public void Initialize(InputReader inputReader,
                           Button saveButton,
                           Button shopButton,
                           Button exitButton,
                           GameObject savesWindow,
                           GameObject shopWindow,
                           TMP_Text coinsText)
    {
        _inputReader = inputReader;
        _inputReader.OnClick += OnClick;

        _saveButton = saveButton;
        _saveButton.onClick.AddListener(OnSaveButtonClick);

        _shopButton = shopButton;
        _shopButton.onClick.AddListener(OnShopButtonClick);

        _exitButton = exitButton;
        _exitButton.onClick.AddListener(OnExitButtonClick);
        
        _savesWindow = savesWindow;
        _shopWindow = shopWindow;

        _coinsText = coinsText;
    }

    public void UpdateCoins(float coins)
    {
        _coinsText.text = $"Coins: {coins}";
    }

    public void ShowSavesWindow()
    {
        _savesWindow.transform.DOMoveY(Screen.height / 2, 0.5f);
    }

    public void HideSavesWindow()
    {
        _savesWindow.transform.DOMoveY(-Screen.height / 2, 0.5f);
    }

    public void ShowShopWindow()
    {
        _shopWindow.transform.DOMoveY(Screen.height / 2, 0.5f);
    }

    public void HideShopWindow()
    {
        _shopWindow.transform.DOMoveY(-Screen.height / 2, 0.5f);
    }

    private void OnClick()
    {
        CharacterClicked?.Invoke();
    }

    private void OnSaveButtonClick()
    {
        SaveButtonClicked?.Invoke();
    }

    private void OnShopButtonClick()
    {
        ShopButtonClicked?.Invoke();
    }

    private void OnExitButtonClick()
    {
        ExitButtonClicked?.Invoke();
    }

    private void OnDestroy()
    {
        _inputReader.OnClick -= OnClick;
        _saveButton.onClick.RemoveListener(OnSaveButtonClick);
        _shopButton.onClick.RemoveListener(OnShopButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }
}
