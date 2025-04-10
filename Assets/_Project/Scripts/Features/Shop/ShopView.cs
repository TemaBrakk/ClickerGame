using System;
using TMPro;
using UnityEngine;

public class ShopView : MonoBehaviour
{
    public Action ShopClicked;
    public Action UpgradeClickPowerClicked;
    public Action UpgradePassiveIncomeClicked;

    private GameObject _shopWindow;
    private TMP_Text _clickPowerButtonText;
    private TMP_Text _passiveIncomeButtonText;

    public void Initialize(GameObject shopWindow,
                           TMP_Text clickPowerButtonText,
                           TMP_Text passiveIncomeButtonText)
    {
        _shopWindow = shopWindow;
        _clickPowerButtonText = clickPowerButtonText;
        _passiveIncomeButtonText = passiveIncomeButtonText;
    }

    public void OnShopButtonClick()
    {
        ShopClicked?.Invoke();
    }

    public void OnUpgradeClickPowerButtonClick()
    {
        UpgradeClickPowerClicked?.Invoke();
    }

    public void OnUpgradePassiveIncomeClick()
    {
        UpgradePassiveIncomeClicked?.Invoke();
    }

    public void ShowShopWindow()
    {
        _shopWindow.SetActive(true);
    }

    public void HideShopWindow()
    {
        _shopWindow.SetActive(false);
    }

    public void UpdateClickPowerButton(int level, float cost)
    {
        _clickPowerButtonText.text = $"Buy lvl {level}\nCost: {cost}";
    }

    public void UpdatePassiveIncomeButton(int level, float cost)
    {
        _passiveIncomeButtonText.text = $"Buy lvl {level}\nCost: {cost}";
    }
}
