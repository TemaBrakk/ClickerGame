using System;
using TMPro;
using UnityEngine;

public class GameView : MonoBehaviour
{
    private InputReader _inputReader;
    private TMP_Text _coinsText;
    public event Action OnClick;

    public void Initialize(InputReader inputReader)
    {
        _inputReader = inputReader;
        _inputReader.OnClick += () => OnClick?.Invoke();

        _coinsText = GetComponentInChildren<TMP_Text>();
    }

    public void UpdateCoins(float coins)
    {
        _coinsText.text = $"Coins: {coins}";
    }

    private void OnDestroy()
    {
        _inputReader.OnClick -= () => OnClick?.Invoke();
    }
}
