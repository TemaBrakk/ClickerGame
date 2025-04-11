public class GameModel
{
    public float Coins { get; private set; }
    public float ClickPower { get; private set; }
    public float PassiveIncome { get; private set; }

    public float PassiveIncomeInterval { get; private set; }

    public void Initialize(StartGameModelStats startStats)
    {
        Coins = startStats.Coins;
        ClickPower = startStats.ClickPower;
        PassiveIncome = startStats.PassiveIncome;
        PassiveIncomeInterval = startStats.PassiveIncomeInterval;
    }

    public void AddCoins(float bonus)
    {
        Coins += bonus;
    }

    public void AddPassiveIncome(float bonus)
    {
        PassiveIncome += bonus;
    }

    public void AddClickPower(float bonus)
    {
        ClickPower += bonus;
    }
}
