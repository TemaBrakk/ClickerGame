public class GamePresenter
{
    private GameView _gameView;
    private GameModel _gameModel;

    public GamePresenter(GameView gameView, GameModel gameModel)
    {
        _gameView = gameView;
        _gameModel = gameModel;

        _gameView.OnClick += OnClick;
    }

    private void OnClick()
    {
        _gameModel.AddCoins(_gameModel.ClickPower);
        _gameView.UpdateCoins(_gameModel.Coins);
    }
}
