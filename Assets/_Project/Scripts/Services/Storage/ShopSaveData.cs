public class ShopSaveData
{
    public float ClickPowerUpgradeCost;
    public int ClickPowerNextLevel;

    public float PassiveIncomeUpgradeCost;
    public int PassiveIncomeNextLevel;

    public float PassiveIncomeIntervalUpgradeCost;
    public int PassiveIncomeIntervalNextLevel;

    public ShopSaveData(float clickPowerUpgradeCost,
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

    public ShopSaveData()
    {
        ClickPowerUpgradeCost = 10f;
        ClickPowerNextLevel = 1;

        PassiveIncomeUpgradeCost = 10f;
        PassiveIncomeNextLevel = 1;

        PassiveIncomeIntervalUpgradeCost = 100f;
        PassiveIncomeIntervalNextLevel = 1;
    }
}
