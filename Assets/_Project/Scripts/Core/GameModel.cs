public class GameModel
{
    public float Coins { get; private set; }

    public float ClickPower { get; private set; }
    public float PassiveIncome { get; private set; }
    public float PassiveIncomeInterval { get; private set; }

    private float _clickPowerBonus;
    private float _passiveIncomeBonus;
    private float _passiveIncomeIntervalMultiplier;

    public void Initialize(StartGameModelStats startStats)
    {
        SetStats(startStats.Coins,
                 startStats.ClickPower,
                 startStats.PassiveIncome,
                 startStats.PassiveIncomeInterval);

        _clickPowerBonus = startStats.ClickPowerBonus;
        _passiveIncomeBonus = startStats.PassiveIncomeBonus;
        _passiveIncomeIntervalMultiplier = startStats.PassiveIncomeIntervalMultiplier;
    }

    public void SetStats(float coins,
                         float clickPower,
                         float passiveIncome,
                         float passiveIncomeInterval)
    {
        Coins = coins;
        ClickPower = clickPower;
        PassiveIncome = passiveIncome;
        PassiveIncomeInterval = passiveIncomeInterval;
    }

    public void AddCoins(float bonus)
    {
        Coins += bonus;
    }

    public void UpgradeClickPower()
    {
        ClickPower += _clickPowerBonus;
    }

    public void UpgradePassiveIncome()
    {
        PassiveIncome += _passiveIncomeBonus;
    }

    public void UpgradePassiveIncomeInterval()
    {
        PassiveIncomeInterval *= _passiveIncomeIntervalMultiplier;
    }
}
