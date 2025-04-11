public class ShopModel
{
    public float ClickPowerUpgradeCost { get; private set; }
    public int ClickPowerNextLevel { get; private set; }
    public float PassiveIncomeUpgradeCost { get; private set; }
    public int PassiveIncomeNextLevel { get; private set; }
    public float PassiveIncomeIntervalUpgradeCost { get; private set; }
    public int PassiveIncomeIntervalNextLevel { get; private set; }

    public bool IsShopWindowActive { get; private set; }

    public void Initialize(StartShopModelStats startStats)
    {
        ClickPowerUpgradeCost = startStats.ClickPowerUpgradeCost;
        ClickPowerNextLevel = startStats.ClickPowerNextLevel;

        PassiveIncomeUpgradeCost = startStats.PassiveIncomeUpgradeCost;
        PassiveIncomeNextLevel = startStats.PassiveIncomeNextLevel;

        PassiveIncomeIntervalUpgradeCost = startStats.PassiveIncomeIntervalUpgradeCost;
        PassiveIncomeIntervalNextLevel = startStats.PassiveIncomeIntervalNextLevel;

        IsShopWindowActive = startStats.IsShopWindowActive;
    }

    public void ChangeShopWindowMode()
    {
        IsShopWindowActive = !IsShopWindowActive;
    }

    public void AddClickPowerUpgradeCost()
    {
        ClickPowerUpgradeCost *= 2f;
        ClickPowerNextLevel += 1;
    }

    public void AddPassiveIncomeUpgradeCost()
    {
        PassiveIncomeUpgradeCost *= 2f;
        PassiveIncomeNextLevel += 1;
    }

    public void AddPassiveIncomeIntervalUpgradeCost()
    {
        PassiveIncomeIntervalUpgradeCost *= 2f;
        PassiveIncomeIntervalNextLevel += 1;
    }
}
