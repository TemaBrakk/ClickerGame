using System.Collections;
using UnityEngine;

public class GamePresenter
{
    private GameView _gameView;
    private GameModel _gameModel;

    private Character _character;

    private IStorage _storage;

    private const string SAVE_FILE_NAME = "Save";

    public void Initialize(GameView gameView,
                           GameModel gameModel,
                           Character character,
                           IStorage storage)
    {
        _gameView = gameView;
        _gameModel = gameModel;
        _character = character;
        _storage = storage;

        SubscribeToView();
        SetStats();
        UpdateSaveSlotsText();
    }

    private void SubscribeToView()
    {
        _gameView.OnClick += OnClick;
        _gameView.SaveButtonClicked += HandleSavesWindow;
        _gameView.SaveFirstSlotButtonClicked += SaveInFirstSlot;
        _gameView.SaveSecondSlotButtonClicked += SaveInSecondSlot;
        _gameView.SaveThirdSlotButtonClicked += SaveInThirdSlot;
        _gameView.ExitButtonClicked += Exit;
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

    private void HandleSavesWindow()
    {
        if (_gameModel.IsSavesWindowActive)
            _gameView.HideSavesWindow();
        else
            _gameView.ShowSavesWindow();

        _gameModel.ChangeSavesWindowMode();
    }

    private void SaveInFirstSlot()
    {
        GameSaveData data = GetSaveData();
        _storage.Save(SAVE_FILE_NAME + "1", data);
        _gameView.UpdateFirstSaveSlotText(false, data.Coins, data.PassiveIncome);
    }

    private void SaveInSecondSlot()
    {
        GameSaveData data = GetSaveData();
        _storage.Save(SAVE_FILE_NAME + "2", data);
        _gameView.UpdateSecondSaveSlotText(false, data.Coins, data.PassiveIncome);
    }

    private void SaveInThirdSlot()
    {
        GameSaveData data = GetSaveData();
        _storage.Save(SAVE_FILE_NAME + "3", data);
        _gameView.UpdateThirdSaveSlotText(false, data.Coins, data.PassiveIncome);
    }

    private void UpdateSaveSlotsText()
    {
        if (!_storage.IsFileExists(SAVE_FILE_NAME + "1"))
        {
            _gameView.UpdateFirstSaveSlotText(true);
        }
        else
        {
            GameSaveData data = _storage.Load<GameSaveData>(SAVE_FILE_NAME + "1");
            _gameView.UpdateFirstSaveSlotText(false, data.Coins, data.PassiveIncome);
        }

        if (!_storage.IsFileExists(SAVE_FILE_NAME + "2"))
        {
            _gameView.UpdateSecondSaveSlotText(true);
        }
        else
        {
            GameSaveData data = _storage.Load<GameSaveData>(SAVE_FILE_NAME + "2");
            _gameView.UpdateSecondSaveSlotText(false, data.Coins, data.PassiveIncome);
        }

        if (!_storage.IsFileExists(SAVE_FILE_NAME + "3"))
        {
            _gameView.UpdateThirdSaveSlotText(true);
        }
        else
        {
            GameSaveData data = _storage.Load<GameSaveData>(SAVE_FILE_NAME + "3");
            _gameView.UpdateThirdSaveSlotText(false, data.Coins, data.PassiveIncome);
        }
    }

    private void Exit()
    {
        SceneLoader.Instance.LoadMainMenuScene();
    }

    private GameSaveData GetSaveData()
    {
        return new GameSaveData(_gameModel.Coins,
                                _gameModel.ClickPower,
                                _gameModel.PassiveIncome,
                                _gameModel.PassiveIncomeInterval);
    }

    private void SetStats()
    {
        GameSaveData data = _storage.Load<GameSaveData>(SAVE_FILE_NAME);
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
        _gameView.SaveButtonClicked -= HandleSavesWindow;
        _gameView.SaveFirstSlotButtonClicked -= SaveInFirstSlot;
        _gameView.SaveSecondSlotButtonClicked -= SaveInSecondSlot;
        _gameView.SaveThirdSlotButtonClicked -= SaveInThirdSlot;
        _gameView.ExitButtonClicked -= Exit;
    }
}
