public class GameModel
{
    public float Coins { get; private set; }
    public float PassiveIncome { get; private set; }
    public float ClickPower { get; private set; }

    public GameModel(float coins, float passiveIncome, float clickPower)
    {
        Coins = coins;
        PassiveIncome = passiveIncome;
        ClickPower = clickPower;
    }

    public void AddCoins(float amount)
    {
        Coins += amount;
    }

    public void SetPassiveIncome(float passiveIncome)
    {
        PassiveIncome = passiveIncome;
    }

    public void SetClickpower(float clickPower)
    {
        ClickPower = clickPower;
    }
}
