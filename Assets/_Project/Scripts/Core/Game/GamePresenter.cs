using System.Collections;
using UnityEngine;

public class GamePresenter
{
    private GameView _gameView;
    private GameModel _gameModel;

    private Character _character;

    private IStorageService _storageService;

    public void Initialize(GameView gameView,
                           GameModel gameModel,
                           Character character)
    {
        _gameView = gameView;
        _gameModel = gameModel;

        _character = character;

        _gameView.OnClick += OnClick;
        _gameView.OnSaveButtonClick += Save;
        _gameView.OnLoadButtonClick += Load;

        _gameView.UpdateCoins(_gameModel.Coins);

        _storageService = new StorageService();
    }

    private void AddCoins(float amount)
    {
        _gameModel.AddCoins(amount);
        _gameView.UpdateCoins(_gameModel.Coins);
    }

    private void OnClick()
    {
        AddCoins(_gameModel.ClickPower);
        _character.OnClick();
    }

    private void Save()
    {
        GameSaveData data = new GameSaveData(_gameModel.Coins,
                                             _gameModel.ClickPower,
                                             _gameModel.PassiveIncome,
                                             _gameModel.PassiveIncomeInterval);

        _storageService.Save("Save", data);
    }

    private void Load()
    {
        _storageService.Load<GameSaveData>("Save", SetStats);
    }

    private void SetStats(GameSaveData data)
    {
        _gameModel.SetStats(data.Coins,
                            data.ClickPower,
                            data.PassiveIncome,
                            data.PassiveIncomeInterval);

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
        _gameView.OnSaveButtonClick -= Save;
        _gameView.OnLoadButtonClick -= Load;
    }
}
