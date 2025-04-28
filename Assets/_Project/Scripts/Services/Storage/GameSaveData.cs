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

    public GameSaveData()
    {
        Coins = 0f;
        ClickPower = 1f;
        PassiveIncome = 0f;
        PassiveIncomeInterval = 1f;
    }
}
