public class GamePresenter
{
    private GameView _gameView;
    private GameModel _gameModel;

    public void Initialize(GameView gameView, GameModel gameModel)
    {
        _gameView = gameView;
        _gameModel = gameModel;

        _gameView.OnClick += OnClick;
    }

    private void OnClick()
    {
        AddMoney(_gameModel.ClickPower);
    }

    public void AddMoneyForPassiveIncome()
    {
        AddMoney(_gameModel.PassiveIncome);
    }

    private void AddMoney(float amount)
    {
        _gameModel.AddCoins(amount);
        _gameView.UpdateCoins(_gameModel.Coins);
    }

    public void AddClickPower()
    {
        _gameModel.AddClickPower(1f);
    }

    public void AddPassiveIncome()
    {
        _gameModel.AddPassiveIncome(0.5f);
    }

    public void OnDestroy()
    {
        _gameView.OnClick -= OnClick;
    }
}
