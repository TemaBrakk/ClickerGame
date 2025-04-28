using System;

[Serializable]
public class SaveData
{
    public float Coins;
    public float ClickPower;
    public float PassiveIncome;
    public float PassiveIncomeInterval;

    public float ClickPowerUpgradeCost;
    public int ClickPowerNextLevel;

    public float PassiveIncomeUpgradeCost;
    public int PassiveIncomeNextLevel;

    public float PassiveIncomeIntervalUpgradeCost;
    public int PassiveIncomeIntervalNextLevel;

    public SaveData(float coins,
                    float clickPower,
                    float passiveIncome,
                    float passiveIncomeInterval,
                    float clickPowerUpgradeCost,
                    int clickPowerNextLevel,
                    float passiveIncomeUpgradeCost,
                    int passiveIncomeNextLevel,
                    float passiveIncomeIntervalUpgradeCost,
                    int passiveIncomeIntervalNextLevel)
    {
        Coins = coins;

        ClickPower = clickPower;
        PassiveIncome = passiveIncome;
        PassiveIncomeInterval = passiveIncomeInterval;

        ClickPowerUpgradeCost = clickPowerUpgradeCost;
        ClickPowerNextLevel = clickPowerNextLevel;

        PassiveIncomeUpgradeCost = passiveIncomeUpgradeCost;
        PassiveIncomeNextLevel = passiveIncomeNextLevel;

        PassiveIncomeIntervalUpgradeCost = passiveIncomeIntervalUpgradeCost;
        PassiveIncomeIntervalNextLevel = passiveIncomeIntervalNextLevel;
    }

    public SaveData()
    {
        Coins = 0f;
        ClickPower = 1f;
        PassiveIncome = 0f;
        PassiveIncomeInterval = 1f;

        ClickPowerUpgradeCost = 10f;
        ClickPowerNextLevel = 1;

        PassiveIncomeUpgradeCost = 10f;
        PassiveIncomeNextLevel = 1;

        PassiveIncomeIntervalUpgradeCost = 100f;
        PassiveIncomeIntervalNextLevel = 1;
    }
}
