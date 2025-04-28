using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopView : MonoBehaviour
{
    public Action UpgradeClickPowerClicked;
    public Action UpgradePassiveIncomeClicked;
    public Action UpgradePassiveIncomeIntervalClicked;

    private Button _upgradeClickPowerButton;
    private Button _upgradePassiveIncomeButton;
    private Button _upgradePassiveIncomeIntervalButton;

    private TMP_Text _clickPowerButtonText;
    private TMP_Text _passiveIncomeButtonText;
    private TMP_Text _passiveIncomeIntervalButtonText;

    public void Initialize(Button upgradeClickPowerButton,
                           Button upgradePassiveIncomeButton,
                           Button upgradePassiveIncomeIntervalButton,
                           TMP_Text clickPowerButtonText,
                           TMP_Text passiveIncomeButtonText,
                           TMP_Text passiveIncomeIntervalButtonText)
    {
        _upgradeClickPowerButton = upgradeClickPowerButton;
        _upgradePassiveIncomeButton = upgradePassiveIncomeButton;
        _upgradePassiveIncomeIntervalButton = upgradePassiveIncomeIntervalButton;

        _clickPowerButtonText = clickPowerButtonText;
        _passiveIncomeButtonText = passiveIncomeButtonText;
        _passiveIncomeIntervalButtonText = passiveIncomeIntervalButtonText;
        
        Subscribe();
    }

    public void UpdateClickPowerButton(int level, float cost)
    {
        _clickPowerButtonText.text = $"Buy lvl {level}\nCost: {cost}";
    }

    public void UpdatePassiveIncomeButton(int level, float cost)
    {
        _passiveIncomeButtonText.text = $"Buy lvl {level}\nCost: {cost}";
    }

    public void UpdatePassiveIncomeIntervalButton(int level, float cost)
    {
        _passiveIncomeIntervalButtonText.text = $"Buy lvl {level}\nCost: {cost}";
    }

    private void Subscribe()
    {
        _upgradeClickPowerButton.onClick.AddListener(OnUpgradeClickPowerButtonClick);
        _upgradePassiveIncomeButton.onClick.AddListener(OnUpgradePassiveIncomeClick);
        _upgradePassiveIncomeIntervalButton.onClick.AddListener(OnUpgradePassiveIncomeIntervalClick);
    }

    private void OnUpgradeClickPowerButtonClick()
    {
        UpgradeClickPowerClicked?.Invoke();
    }

    private void OnUpgradePassiveIncomeClick()
    {
        UpgradePassiveIncomeClicked?.Invoke();
    }

    private void OnUpgradePassiveIncomeIntervalClick()
    {
        UpgradePassiveIncomeIntervalClicked?.Invoke();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void Unsubscribe()
    {
        _upgradeClickPowerButton.onClick.RemoveListener(OnUpgradeClickPowerButtonClick);
        _upgradePassiveIncomeButton.onClick.RemoveListener(OnUpgradePassiveIncomeClick);
        _upgradePassiveIncomeIntervalButton.onClick.RemoveListener(OnUpgradePassiveIncomeIntervalClick);
    }
}
