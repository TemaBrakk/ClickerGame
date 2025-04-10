public class ShopModel
{
    public float ClickPowerUpgradeCost { get; private set; }
    public int ClickPowerNextLevel { get; private set; }
    public float PassiveIncomeUpgradeCost { get; private set; }
    public int PassiveIncomeNextLevel { get; private set; }

    public bool IsShopWindowActive { get; private set; }

    public void Initialize()
    {
        ClickPowerUpgradeCost = 0f;
        ClickPowerNextLevel = 1;

        PassiveIncomeUpgradeCost = 10f;
        PassiveIncomeNextLevel = 1;

        IsShopWindowActive = false;
    }

    public void ChangeShopWindowMode()
    {
        IsShopWindowActive = !IsShopWindowActive;
    }

    public void AddClickPowerUpgradeCost()
    {
        ClickPowerUpgradeCost += 10f;
        ClickPowerNextLevel += 1;
    }

    public void AddPassiveIncomeUpgradeCost()
    {
        PassiveIncomeUpgradeCost *= 2f;
        PassiveIncomeNextLevel += 1;
    }
}
