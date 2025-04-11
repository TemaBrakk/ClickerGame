using System.Collections;
using UnityEngine;

public class GamePresenter
{
    private GameView _gameView;
    private GameModel _gameModel;

    private Character _character;

    public void Initialize(GameView gameView,
                           GameModel gameModel,
                           Character character)
    {
        _gameView = gameView;
        _gameModel = gameModel;

        _character = character;

        _gameView.OnClick += OnClick;
    }

    private void OnClick()
    {
        AddCoins(_gameModel.ClickPower);
        _character.OnClick();
    }

    private void AddCoins(float amount)
    {
        _gameModel.AddCoins(amount);
        _gameView.UpdateCoins(_gameModel.Coins);
    }

    public bool TryAddClickPower(float cost)
    {
        if (IsEnoughCoins(cost))
        {
            _gameModel.AddClickPower(1f);
            AddCoins(-cost);
            return true;
        }

        return false;
    }

    public bool TryAddPassiveIncome(float cost)
    {
        if (IsEnoughCoins(cost))
        {
            _gameModel.AddPassiveIncome(0.5f);
            AddCoins(-cost);
            return true;
        }

        return false;
    }

    public IEnumerator IncomeRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_gameModel.PassiveIncomeInterval);
            AddCoins(_gameModel.PassiveIncome);
        }
    }

    public bool IsEnoughCoins(float cost)
    {
        return cost <= _gameModel.Coins;
    }

    public void OnDestroy()
    {
        _gameView.OnClick -= OnClick;
    }
}
