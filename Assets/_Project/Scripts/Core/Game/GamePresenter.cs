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

        SubscribeToView();
    }

    private void SubscribeToView()
    {
        _gameView.CharacterClicked += OnClick;
        _gameView.SaveButtonClicked += OnSaveButtonClick;
        _gameView.ShopButtonClicked += OnShopButtonClick;
        _gameView.ExitButtonClicked += OnExitButtonClick;
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

    private void OnSaveButtonClick()
    {
        HandleSavesWindow();
    }

    private void OnShopButtonClick()
    {
        HandleShopWindow();
    }

    private void HandleSavesWindow()
    {
        if (_gameModel.IsSavesWindowActive)
            _gameView.HideSavesWindow();
        else
            _gameView.ShowSavesWindow();

        if (_gameModel.IsShopWindowActive)
            HandleShopWindow();

        _gameModel.ChangeSavesWindowMode();
    }

    private void HandleShopWindow()
    {
        if (_gameModel.IsShopWindowActive)
            _gameView.HideShopWindow();
        else
            _gameView.ShowShopWindow();

        if (_gameModel.IsSavesWindowActive)
            HandleSavesWindow();

        _gameModel.ChangeShopWindowMode();
    }

    private void OnExitButtonClick()
    {
        SceneLoader.Instance.LoadMainMenuScene();
    }

    public GameSaveData GetSaveData()
    {
        return new GameSaveData(_gameModel.Coins,
                                _gameModel.ClickPower,
                                _gameModel.PassiveIncome,
                                _gameModel.PassiveIncomeInterval);
    }

    public void SetStats(GameSaveData data)
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
        _gameView.CharacterClicked -= OnClick;
        _gameView.SaveButtonClicked -= OnSaveButtonClick;
        _gameView.SaveButtonClicked -= OnShopButtonClick;
        _gameView.ExitButtonClicked -= OnExitButtonClick;
    }
}
