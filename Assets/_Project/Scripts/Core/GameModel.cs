public class GameModel
{
    public float Coins { get; private set; }
    public float ClickPower { get; private set; }
    public float PassiveIncome { get; private set; }

    public void Initialize(float coins, float clickPower, float passiveIncome)
    {
        Coins = coins;
        ClickPower = clickPower;
        PassiveIncome = passiveIncome;
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
