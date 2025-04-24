using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class GameView : MonoBehaviour
{
    public event Action OnClick;
    public event Action SaveButtonClicked;
    public event Action SaveFirstSlotButtonClicked;
    public event Action SaveSecondSlotButtonClicked;
    public event Action SaveThirdSlotButtonClicked;
    public event Action ExitButtonClicked;

    private InputReader _inputReader;
    private TMP_Text _coinsText;

    private GameObject _savesWindow;
    private Button _saveButton;
    private Button _saveFirstSlotButton;
    private Button _saveSecondSlotButton;
    private Button _saveThirdSlotButton;
    private Button _exitButton;

    private TMP_Text _firstSlotInfoText;
    private TMP_Text _secondSlotInfoText;
    private TMP_Text _thirdSlotInfoText;

    public void Initialize(InputReader inputReader,
                           TMP_Text coinsText,
                           GameObject savesWindow,
                           Button saveButton,
                           Button saveFirstSlotButton,
                           Button saveSecondSlotButton,
                           Button saveThirdSlotButton,
                           Button exitButton,
                           TMP_Text firstSlotInfoText,
                           TMP_Text secondSlotInfoText,
                           TMP_Text thirdSlotInfoText)
    {
        _inputReader = inputReader;
        _inputReader.OnClick += () => OnClick?.Invoke();

        _coinsText = coinsText;

        _savesWindow = savesWindow;

        _saveButton = saveButton;
        _saveButton.onClick.AddListener(OnSaveButtonClick);

        _saveFirstSlotButton = saveFirstSlotButton;
        _saveFirstSlotButton.onClick.AddListener(OnSaveFirstSlotButtonClick);

        _saveSecondSlotButton = saveSecondSlotButton;
        _saveSecondSlotButton.onClick.AddListener(OnSaveSecondSlotButtonClick);

        _saveThirdSlotButton = saveThirdSlotButton;
        _saveThirdSlotButton.onClick.AddListener(OnSaveThirdSlotButtonClick);

        _exitButton = exitButton;
        _exitButton.onClick.AddListener(OnExitButtonClick);

        _firstSlotInfoText = firstSlotInfoText;
        _secondSlotInfoText = secondSlotInfoText;
        _thirdSlotInfoText = thirdSlotInfoText;
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

    public void UpdateFirstSaveSlotText(bool isEmpty, float coins = 0, float passiveIncome = 0)
    {
        if (isEmpty)
            _firstSlotInfoText.text = "Empty slot";
        else
            _firstSlotInfoText.text = $"Coins: {coins}\nPassive income {passiveIncome}";
    }

    public void UpdateSecondSaveSlotText(bool isEmpty, float coins = 0, float passiveIncome = 0)
    {
        if (isEmpty)
            _secondSlotInfoText.text = "Empty slot";
        else
            _secondSlotInfoText.text = $"Coins: {coins}\nPassive income {passiveIncome}";
    }

    public void UpdateThirdSaveSlotText(bool isEmpty, float coins = 0, float passiveIncome = 0)
    {
        if (isEmpty)
            _thirdSlotInfoText.text = "Empty slot";
        else
            _thirdSlotInfoText.text = $"Coins: {coins}\nPassive income {passiveIncome}";
    }

    private void OnSaveButtonClick()
    {
        SaveButtonClicked?.Invoke();
    }

    private void OnSaveFirstSlotButtonClick()
    {
        SaveFirstSlotButtonClicked?.Invoke();
    }

    private void OnSaveSecondSlotButtonClick()
    {
        SaveSecondSlotButtonClicked?.Invoke();
    }

    private void OnSaveThirdSlotButtonClick()
    {
        SaveThirdSlotButtonClicked?.Invoke();
    }

    private void OnExitButtonClick()
    {
        ExitButtonClicked?.Invoke();
    }

    private void OnDestroy()
    {
        _inputReader.OnClick -= () => OnClick?.Invoke();
        _saveButton.onClick.RemoveListener(OnSaveButtonClick);
        _saveFirstSlotButton.onClick.RemoveListener(OnSaveFirstSlotButtonClick);
        _saveSecondSlotButton.onClick.RemoveListener(OnSaveSecondSlotButtonClick);
        _saveThirdSlotButton.onClick.RemoveListener(OnSaveThirdSlotButtonClick);
    }
}
