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

        _gameView.UpdateCoins(_gameModel.Coins);
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

    public bool TryUpgradeClickPower(float cost)
    {
        if (IsEnoughCoins(cost))
        {
            _gameModel.UpgradeClickPower();
            AddCoins(-cost);
            return true;
        }

        return false;
    }

    public bool TryUpgradePassiveIncome(float cost)
    {
        if (IsEnoughCoins(cost))
        {
            _gameModel.UpgradePassiveIncome();
            AddCoins(-cost);
            return true;
        }

        return false;
    }

    public bool TryUpgradePassiveIncomeInterval(float cost)
    {
        if (IsEnoughCoins(cost))
        {
            _gameModel.UpgradePassiveIncomeInterval();
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
