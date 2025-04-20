using System;

[Serializable]
public class GameSaveData
{
    public float Coins;

    public float ClickPower;
    public float PassiveIncome;
    public float PassiveIncomeInterval;

    public GameSaveData(float coins,
                        float clickPower,
                        float passiveIncome,
                        float passiveIncomeInterval)
    {
        Coins = coins;
        ClickPower = clickPower;
        PassiveIncome = passiveIncome;
        PassiveIncomeInterval = passiveIncomeInterval;
    }
}
