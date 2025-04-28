using System.Threading;

public class SavePresenter
{
    private SaveModel _saveModel;
    private SaveView _saveView;

    private GamePresenter _gamePresenter;
    private ShopPresenter _shopPresenter;

    private IStorage _storage;

    private bool _isAll;

    private const string SAVE_FILE_NAME = "Save";

    public void Initialize(SaveModel saveModel,
                           SaveView saveView,
                           GamePresenter gamePresenter,
                           ShopPresenter shopPresenter,
                           IStorage storage)
    {
        _saveModel = saveModel;
        _saveView = saveView;
        _gamePresenter = gamePresenter;
        _shopPresenter = shopPresenter;
        _storage = storage;

        _isAll = true;

        Subscribe();
        Prepare();
        SetStats();
    }

    public void Initialize(SaveModel saveModel, 
                           SaveView saveView,
                           IStorage storage)
    {
        _saveModel = saveModel;
        _saveView = saveView;
        _storage = storage;

        _isAll = false;

        Subscribe();
        Prepare();
    }

    private void Subscribe()
    {
        if (_isAll)
        {
            _saveView.SaveFirstSlotButtonClicked += SaveInFirstSlot;
            _saveView.SaveSecondSlotButtonClicked += SaveInSecondSlot;
            _saveView.SaveThirdSlotButtonClicked += SaveInThirdSlot;
        }

        _saveView.LoadFirstSlotButtonClicked += LoadFirstSaveSlot;
        _saveView.LoadSecondSlotButtonClicked += LoadSecondSaveSlot;
        _saveView.LoadThirdSlotButtonClicked += LoadThirdSaveSlot;
    }

    private void Prepare()
    {
        if (!_storage.IsFileExists(SAVE_FILE_NAME + "1"))
        {
            _saveView.UpdateFirstSaveSlotText();
        }
        else
        {
            SaveData data = _storage.Load<SaveData>(SAVE_FILE_NAME + "1");
            _saveView.UpdateFirstSaveSlotText(data.Coins, data.PassiveIncome);
            _saveModel.SetFirstSaveSlotData(data);
        }

        if (!_storage.IsFileExists(SAVE_FILE_NAME + "2"))
        {
            _saveView.UpdateSecondSaveSlotText();
        }
        else
        {
            SaveData data = _storage.Load<SaveData>(SAVE_FILE_NAME + "2");
            _saveView.UpdateSecondSaveSlotText(data.Coins, data.PassiveIncome);
            _saveModel.SetSecondSaveSlotData(data);
        }

        if (!_storage.IsFileExists(SAVE_FILE_NAME + "3"))
        {
            _saveView.UpdateThirdSaveSlotText();
        }
        else
        {
            SaveData data = _storage.Load<SaveData>(SAVE_FILE_NAME + "3");
            _saveView.UpdateThirdSaveSlotText(data.Coins, data.PassiveIncome);
            _saveModel.SetThirdSaveSlotData(data);
        }
    }

    private void SetStats()
    {
        SaveData data = _storage.Load<SaveData>(SAVE_FILE_NAME);
        _gamePresenter.SetStats(data);
        _shopPresenter.SetStats(data);
        _saveModel.SetMainSaveData(data);
    }

    private void SaveInFirstSlot()
    {
        SaveData data = Save("1");
        _saveView.UpdateFirstSaveSlotText(data.Coins, data.PassiveIncome);
        _saveModel.SetFirstSaveSlotData(data);
    }

    private void SaveInSecondSlot()
    {
        SaveData data = Save("2");
        _saveView.UpdateSecondSaveSlotText(data.Coins, data.PassiveIncome);
        _saveModel.SetSecondSaveSlotData(data);
    }

    private void SaveInThirdSlot()
    {
        SaveData data = Save("3");
        _saveView.UpdateThirdSaveSlotText(data.Coins, data.PassiveIncome);
        _saveModel.SetThirdSaveSlotData(data);
    }

    private SaveData Save(string slotNumber)
    {
        string key = SAVE_FILE_NAME + slotNumber;

        GameSaveData gameSaveData = _gamePresenter.GetSaveData();
        ShopSaveData shopSaveData = _shopPresenter.GetSaveData();

        SaveData data = new SaveData(gameSaveData.Coins,
                                     gameSaveData.ClickPower,
                                     gameSaveData.PassiveIncome,
                                     gameSaveData.PassiveIncomeInterval,
                                     shopSaveData.ClickPowerUpgradeCost,
                                     shopSaveData.ClickPowerNextLevel,
                                     shopSaveData.PassiveIncomeUpgradeCost,
                                     shopSaveData.PassiveIncomeNextLevel,
                                     shopSaveData.PassiveIncomeIntervalUpgradeCost,
                                     shopSaveData.PassiveIncomeIntervalNextLevel);

        _storage.Save(key, data);

        return data;
    }

    private void LoadFirstSaveSlot()
    {
        Load("1");
        SceneLoader.Instance.LoadGameScene();
    }

    private void LoadSecondSaveSlot()
    {
        Load("2");
        SceneLoader.Instance.LoadGameScene();
    }

    private void LoadThirdSaveSlot()
    {
        Load("3");
        SceneLoader.Instance.LoadGameScene();
    }

    private void Load(string slotNumber)
    {
        string key = SAVE_FILE_NAME + slotNumber;

        if (!_storage.IsFileExists(key))
            _storage.Save(key, new SaveData());

        SaveData data = _storage.Load<SaveData>(key);
        _storage.Save(SAVE_FILE_NAME, data);
        _saveModel.SetMainSaveData(data);
    }

    public void OnDestroy()
    {
        Unsubscribe();
    }

    private void Unsubscribe()
    {
        if (_isAll)
        {
            _saveView.SaveFirstSlotButtonClicked -= SaveInFirstSlot;
            _saveView.SaveSecondSlotButtonClicked -= SaveInSecondSlot;
            _saveView.SaveThirdSlotButtonClicked -= SaveInThirdSlot;
        }

        _saveView.LoadFirstSlotButtonClicked -= LoadFirstSaveSlot;
        _saveView.LoadSecondSlotButtonClicked -= LoadSecondSaveSlot;
        _saveView.LoadThirdSlotButtonClicked -= LoadThirdSaveSlot;
    }
}
