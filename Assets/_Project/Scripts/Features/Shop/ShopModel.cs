public class ShopModel
{
    public float ClickPowerUpgradeCost { get; private set; }
    public int ClickPowerNextLevel { get; private set; }
    public float PassiveIncomeUpgradeCost { get; private set; }
    public int PassiveIncomeNextLevel { get; private set; }
    public float PassiveIncomeIntervalUpgradeCost { get; private set; }
    public int PassiveIncomeIntervalNextLevel { get; private set; }
    public float UpgradeCostModifier { get; private set; }

    public void Initialize(ShopModelStats startStats)
    {
        UpgradeCostModifier = startStats.UpgradeCostModifier;
    }

    public void SetStats(float clickPowerUpgradeCost,
                         int clickPowerNextLevel,
                         float passiveIncomeUpgradeCost,
                         int passiveIncomeNextLevel,
                         float passiveIncomeIntervalUpgradeCost,
                         int passiveIncomeIntervalNextLevel)
    {
        ClickPowerUpgradeCost = clickPowerUpgradeCost;
        ClickPowerNextLevel = clickPowerNextLevel;

        PassiveIncomeUpgradeCost = passiveIncomeUpgradeCost;
        PassiveIncomeNextLevel = passiveIncomeNextLevel;

        PassiveIncomeIntervalUpgradeCost = passiveIncomeIntervalUpgradeCost;
        PassiveIncomeIntervalNextLevel = passiveIncomeIntervalNextLevel;
    }

    public void AddClickPowerUpgradeCost()
    {
        ClickPowerUpgradeCost *= UpgradeCostModifier;
        ClickPowerNextLevel += 1;
    }

    public void AddPassiveIncomeUpgradeCost()
    {
        PassiveIncomeUpgradeCost *= UpgradeCostModifier;
        PassiveIncomeNextLevel += 1;
    }

    public void AddPassiveIncomeIntervalUpgradeCost()
    {
        PassiveIncomeIntervalUpgradeCost *= UpgradeCostModifier;
        PassiveIncomeIntervalNextLevel += 1;
    }
}
