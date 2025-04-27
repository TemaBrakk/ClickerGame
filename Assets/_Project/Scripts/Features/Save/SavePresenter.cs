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
                           IStorage storage,
                           GamePresenter gamePresenter,
                           ShopPresenter shopPresenter)
    {
        _saveModel = saveModel;
        _saveView = saveView;
        _gamePresenter = gamePresenter;
        _shopPresenter = shopPresenter;
        _storage = storage;

        _isAll = true;

        Subscribe();
        UpdateSaveSlotsText();
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
        UpdateSaveSlotsText();
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

    private void UpdateSaveSlotsText()
    {
        if (!_storage.IsFileExists(SAVE_FILE_NAME + "1"))
        {
            _saveView.UpdateFirstSaveSlotText(true);
        }
        else
        {
            GameSaveData data = _storage.Load<GameSaveData>(SAVE_FILE_NAME + "1");
            _saveView.UpdateFirstSaveSlotText(false, data.Coins, data.PassiveIncome);
        }

        if (!_storage.IsFileExists(SAVE_FILE_NAME + "2"))
        {
            _saveView.UpdateSecondSaveSlotText(true);
        }
        else
        {
            GameSaveData data = _storage.Load<GameSaveData>(SAVE_FILE_NAME + "2");
            _saveView.UpdateSecondSaveSlotText(false, data.Coins, data.PassiveIncome);
        }

        if (!_storage.IsFileExists(SAVE_FILE_NAME + "3"))
        {
            _saveView.UpdateThirdSaveSlotText(true);
        }
        else
        {
            GameSaveData data = _storage.Load<GameSaveData>(SAVE_FILE_NAME + "3");
            _saveView.UpdateThirdSaveSlotText(false, data.Coins, data.PassiveIncome);
        }
    }

    private void SetStats()
    {
        GameSaveData data = _storage.Load<GameSaveData>(SAVE_FILE_NAME);
        _gamePresenter.SetStats(data);
    }

    private void SaveInFirstSlot()
    {
        GameSaveData data = _gamePresenter.GetSaveData();
        _storage.Save(SAVE_FILE_NAME + "1", data);
        _saveView.UpdateFirstSaveSlotText(false, data.Coins, data.PassiveIncome);
    }

    private void SaveInSecondSlot()
    {
        GameSaveData data = _gamePresenter.GetSaveData();
        _storage.Save(SAVE_FILE_NAME + "2", data);
        _saveView.UpdateSecondSaveSlotText(false, data.Coins, data.PassiveIncome);
    }

    private void SaveInThirdSlot()
    {
        GameSaveData data = _gamePresenter.GetSaveData();
        _storage.Save(SAVE_FILE_NAME + "3", data);
        _saveView.UpdateThirdSaveSlotText(false, data.Coins, data.PassiveIncome);
    }

    private void LoadFirstSaveSlot()
    {
        HandleSaves("1");
        SceneLoader.Instance.LoadGameScene();
    }

    private void LoadSecondSaveSlot()
    {
        HandleSaves("2");
        SceneLoader.Instance.LoadGameScene();
    }

    private void LoadThirdSaveSlot()
    {
        HandleSaves("3");
        SceneLoader.Instance.LoadGameScene();
    }

    private void HandleSaves(string slotNumber)
    {
        string key = SAVE_FILE_NAME + slotNumber;

        if (!_storage.IsFileExists(key))
            _storage.Save(key, new GameSaveData(0f, 1f, 0f, 1f));

        GameSaveData saveData = _storage.Load<GameSaveData>(key);
        _storage.Save(SAVE_FILE_NAME, saveData);
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
