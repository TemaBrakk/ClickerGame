using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameEntryPoint : MonoBehaviour
{
    [Header("Views")]
    [SerializeField] private GameView _gameView;
    [SerializeField] private ShopView _shopView;
    [SerializeField] private SaveView _saveView;

    [Header("Game Buttons")]
    [SerializeField] private Button _saveButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _exitButton;
    
    [Header("Shop Buttons")]
    [SerializeField] private Button _upgradeClickPowerButton;
    [SerializeField] private Button _upgradePassiveIncomeButton;
    [SerializeField] private Button _upgradePassiveIncomeIntervalButton;

    [Header("Save Buttons")]
    [SerializeField] private Button _saveFirstSlotButton;
    [SerializeField] private Button _saveSecondSlotButton;
    [SerializeField] private Button _saveThirdSlotButton;
    [SerializeField] private Button _loadFirstSlotButton;
    [SerializeField] private Button _loadSecondSlotButton;
    [SerializeField] private Button _loadThirdSlotButton;

    [Header("Game Text")]
    [SerializeField] private TMP_Text _coinsText;

    [Header("Shop Text")]
    [SerializeField] private TMP_Text _clickPowerButtonText;
    [SerializeField] private TMP_Text _passiveIncomeButtonText;
    [SerializeField] private TMP_Text _passiveIncomeIntervalButtonText;

    [Header("Save Text")]
    [SerializeField] private TMP_Text _firstSaveSlotInfoText;
    [SerializeField] private TMP_Text _secondSaveSlotInfoText;
    [SerializeField] private TMP_Text _thirdSaveSlotInfoText;

    [Header("Windows")]
    [SerializeField] private GameObject _savesWindow;
    [SerializeField] private GameObject _shopWindow;
    
    [Header("Configs")]
    [SerializeField] private GameModelStats _gameModelStats;
    [SerializeField] private ShopModelStats _shopModelStats;

    [Header("Entities")]
    [SerializeField] private Character _character;

    private GameModel _gameModel;
    private GamePresenter _gamePresenter;

    private ShopModel _shopModel;
    private ShopPresenter _shopPresenter;

    private SaveModel _saveModel;
    private SavePresenter _savePresenter;

    private InputReader _inputReader;
    private Updater _updater;
    private IStorage _storage;

    private const string UPDATER_PATH = "Prefabs/Updater";


    private void Awake()
    {
        InitializeServices();
        InitializeEntities();

        InitializeGameMVP();
        InitializeShopMVP();
        InitializeSaveMVP();
    }

    private void InitializeServices()
    {
        _inputReader = new InputReader();

        Updater prefab = Resources.Load<Updater>(UPDATER_PATH);
        _updater = Instantiate(prefab);
        _updater.Initialize();
        _updater.AddUpdatable(_inputReader);

        _storage = new Storage();
    }

    private void InitializeEntities()
    {
        _character.Initialize();
    }

    private void InitializeGameMVP()
    {
        _gameModel = new GameModel();
        _gamePresenter = new GamePresenter();

        _gameModel.Initialize(_gameModelStats);
        _gameView.Initialize(_inputReader, _saveButton, _shopButton, _exitButton, _savesWindow, _shopWindow, _coinsText);
        _gamePresenter.Initialize(_gameView, _gameModel, _character);

        StartCoroutine(_gamePresenter.IncomeRoutine());
    }

    private void InitializeShopMVP()
    {
        _shopModel = new ShopModel();
        _shopPresenter = new ShopPresenter();

        _shopModel.Initialize(_shopModelStats);
        _shopView.Initialize(_upgradeClickPowerButton, _upgradePassiveIncomeButton, _upgradePassiveIncomeIntervalButton, _clickPowerButtonText, _passiveIncomeButtonText, _passiveIncomeIntervalButtonText);
        _shopPresenter.Initialize(_shopModel, _shopView, _gamePresenter);
    }

    private void InitializeSaveMVP()
    {
        _saveModel = new SaveModel();
        _savePresenter = new SavePresenter();

        _saveModel.Initialize();
        _saveView.Initialize(_saveFirstSlotButton, _saveSecondSlotButton, _saveThirdSlotButton, _loadFirstSlotButton, _loadSecondSlotButton, _loadThirdSlotButton, _firstSaveSlotInfoText, _secondSaveSlotInfoText, _thirdSaveSlotInfoText);
        _savePresenter.Initialize(_saveModel, _saveView, _gamePresenter, _shopPresenter, _storage);
    }

    private void OnDestroy()
    {
        _gamePresenter.OnDestroy();
        _shopPresenter.OnDestroy();
        _savePresenter.OnDestroy();
    }
}
