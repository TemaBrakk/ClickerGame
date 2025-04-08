using System;
using UnityEngine;

public class ShopView : MonoBehaviour
{
    public Action ShopClicked;
    public Action UpgradeClickPowerClicked;
    public Action UpgradePassiveIncomeClicked;

    private GameObject _shopWindow;

    public void Initialize(GameObject shopWindow)
    {
        _shopWindow = shopWindow;
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
}
