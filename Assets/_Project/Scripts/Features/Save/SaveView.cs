using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveView : MonoBehaviour
{
    public event Action SaveFirstSlotButtonClicked;
    public event Action SaveSecondSlotButtonClicked;
    public event Action SaveThirdSlotButtonClicked;

    public event Action LoadFirstSlotButtonClicked;
    public event Action LoadSecondSlotButtonClicked;
    public event Action LoadThirdSlotButtonClicked;

    private Button _saveFirstSlotButton;
    private Button _saveSecondSlotButton;
    private Button _saveThirdSlotButton;

    private Button _loadFirstSlotButton;
    private Button _loadSecondSlotButton;
    private Button _loadThirdSlotButton;

    private TMP_Text _firstLoadSlotText;
    private TMP_Text _secondLoadSlotText;
    private TMP_Text _thirdLoadSlotText;

    private bool _isAll;

    public void Initialize(Button saveFirstSlotButton,
                           Button saveSecondSlotButton,
                           Button saveThirdSlotButton,
                           Button loadFirstSlotButton,
                           Button loadSecondSlotButton,
                           Button loadThirdSlotButton,
                           TMP_Text firstLoadSlotText,
                           TMP_Text secondLoadSlotText,
                           TMP_Text thirdLoadSlotText)
    {
        _saveFirstSlotButton = saveFirstSlotButton;
        _saveSecondSlotButton = saveSecondSlotButton;
        _saveThirdSlotButton = saveThirdSlotButton;

        _loadFirstSlotButton = loadFirstSlotButton;
        _loadSecondSlotButton = loadSecondSlotButton;
        _loadThirdSlotButton = loadThirdSlotButton;

        _firstLoadSlotText = firstLoadSlotText;
        _secondLoadSlotText = secondLoadSlotText;
        _thirdLoadSlotText = thirdLoadSlotText;

        _isAll = true;

        Subscribe();
    }

    public void Initialize(Button loadFirstSlotButton,
                           Button loadSecondSlotButton,
                           Button loadThirdSlotButton,
                           TMP_Text firstLoadSlotText,
                           TMP_Text secondLoadSlotText,
                           TMP_Text thirdLoadSlotText)
    {
        _loadFirstSlotButton = loadFirstSlotButton;
        _loadSecondSlotButton = loadSecondSlotButton;
        _loadThirdSlotButton = loadThirdSlotButton;

        _firstLoadSlotText = firstLoadSlotText;
        _secondLoadSlotText = secondLoadSlotText;
        _thirdLoadSlotText = thirdLoadSlotText;

        _isAll = false;

        Subscribe();
    }

    private void Subscribe()
    {
        if (_isAll)
        {
            _saveFirstSlotButton.onClick.AddListener(OnSaveFirstSlotButtonCLick);
            _saveSecondSlotButton.onClick.AddListener(OnSaveSecondSlotButtonCLick);
            _saveThirdSlotButton.onClick.AddListener(OnSaveThirdSlotButtonCLick);
        }

        _loadFirstSlotButton.onClick.AddListener(OnLoadFirstSlotButtonCLick);
        _loadSecondSlotButton.onClick.AddListener(OnLoadSecondSlotButtonCLick);
        _loadThirdSlotButton.onClick.AddListener(OnLoadThirdSlotButtonCLick);
    }

    public void UpdateFirstSaveSlotText(bool isEmpty, float coins = 0, float passiveIncome = 0)
    {
        if (isEmpty)
            _firstLoadSlotText.text = "Empty slot";
        else
            _firstLoadSlotText.text = $"Coins: {coins}\nPassive income: {passiveIncome}";
    }

    public void UpdateSecondSaveSlotText(bool isEmpty, float coins = 0, float passiveIncome = 0)
    {
        if (isEmpty)
            _secondLoadSlotText.text = "Empty slot";
        else
            _secondLoadSlotText.text = $"Coins: {coins}\nPassive income: {passiveIncome}";
    }

    public void UpdateThirdSaveSlotText(bool isEmpty, float coins = 0, float passiveIncome = 0)
    {
        if (isEmpty)
            _thirdLoadSlotText.text = "Empty slot";
        else
            _thirdLoadSlotText.text = $"Coins: {coins}\nPassive income: {passiveIncome}";
    }

    private void OnSaveFirstSlotButtonCLick()
    {
        SaveFirstSlotButtonClicked?.Invoke();
    }

    private void OnSaveSecondSlotButtonCLick()
    {
        SaveSecondSlotButtonClicked?.Invoke();
    }

    private void OnSaveThirdSlotButtonCLick()
    {
        SaveThirdSlotButtonClicked?.Invoke();
    }

    private void OnLoadFirstSlotButtonCLick()
    {
        LoadFirstSlotButtonClicked?.Invoke();
    }

    private void OnLoadSecondSlotButtonCLick()
    {
        LoadSecondSlotButtonClicked?.Invoke();
    }

    private void OnLoadThirdSlotButtonCLick()
    {
        LoadThirdSlotButtonClicked?.Invoke();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void Unsubscribe()
    {
        if (_isAll)
        {
            _saveFirstSlotButton.onClick.RemoveListener(OnSaveFirstSlotButtonCLick);
            _saveSecondSlotButton.onClick.RemoveListener(OnSaveSecondSlotButtonCLick);
            _saveThirdSlotButton.onClick.RemoveListener(OnSaveThirdSlotButtonCLick);
        }

        _loadFirstSlotButton.onClick.RemoveListener(OnLoadFirstSlotButtonCLick);
        _loadSecondSlotButton.onClick.RemoveListener(OnLoadSecondSlotButtonCLick);
        _loadThirdSlotButton.onClick.RemoveListener(OnLoadThirdSlotButtonCLick);
    }
}
