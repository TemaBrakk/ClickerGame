using System;
using TMPro;
using UnityEngine;

public class GameView : MonoBehaviour
{
    private InputReader _inputReader;
    private TMP_Text _coinsText;

    public event Action OnClick;
    public event Action OnSaveButtonClick;
    public event Action OnLoadButtonClick;

    public void Initialize(InputReader inputReader, TMP_Text coinsText)
    {
        _inputReader = inputReader;
        _inputReader.OnClick += () => OnClick?.Invoke();

        _coinsText = coinsText;
    }

    public void UpdateCoins(float coins)
    {
        _coinsText.text = $"Coins: {coins}";
    }

    public void Save()
    {
        OnSaveButtonClick?.Invoke();
    }

    public void Load()
    {
        OnLoadButtonClick?.Invoke();
    }

    private void OnDestroy()
    {
        _inputReader.OnClick -= () => OnClick?.Invoke();
    }
}
