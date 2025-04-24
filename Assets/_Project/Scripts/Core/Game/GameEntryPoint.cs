using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameEntryPoint : MonoBehaviour
{
    [Header("MVP")]
    [SerializeField] private GameView _gameView;
    [SerializeField] private ShopView _shopView;
    [SerializeField] private Character _character;

    [Header("UI")]
    [SerializeField] private TMP_Text _coinsText;
    [SerializeField] private GameObject _shopWindow;
    [SerializeField] private TMP_Text _clickPowerButtonText;
    [SerializeField] private TMP_Text _passiveIncomeButtonText;
    [SerializeField] private TMP_Text _passiveIncomeIntervalButtonText;

    [SerializeField] private Button _saveButton;
    [SerializeField] private Button _saveFirstSlotButton;
    [SerializeField] private Button _saveSecondSlotButton;
    [SerializeField] private Button _saveThirdSlotButton;
    [SerializeField] private GameObject _savesWindow;

    [SerializeField] private Button _exitButton;

    [SerializeField] private TMP_Text _firstSlotInfoText;
    [SerializeField] private TMP_Text _secondSlotInfoText;
    [SerializeField] private TMP_Text _thirdSlotInfoText;

    [Header("Configs")]
    [SerializeField] private StartGameModelStats _startGameModelStats;
    [SerializeField] private StartShopModelStats _startShopModelStats;

    private GameModel _gameModel;
    private GamePresenter _gamePresenter;

    private ShopModel _shopModel;
    private ShopPresenter _shopPresenter;

    private Updater _updater;
    private const string UPDATER_PATH = "Prefabs/Updater";
    private InputReader _inputReader;
    private IStorage _storage;


    private void Awake()
    {
        InitializeServices();

        _character.Initialize();

        InitializeGameMVP();
        InitializeShopMVP();
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

    private void InitializeGameMVP()
    {
        _gameModel = new GameModel();
        _gamePresenter = new GamePresenter();

        _gameView.Initialize(_inputReader, _coinsText, _savesWindow, _saveButton, _saveFirstSlotButton, _saveSecondSlotButton, _saveThirdSlotButton, _exitButton, _firstSlotInfoText, _secondSlotInfoText, _thirdSlotInfoText);
        _gameModel.Initialize(_startGameModelStats);
        _gamePresenter.Initialize(_gameView, _gameModel, _character, _storage);

        StartCoroutine(_gamePresenter.IncomeRoutine());
    }

    private void InitializeShopMVP()
    {
        _shopModel = new ShopModel();
        _shopPresenter = new ShopPresenter();

        _shopModel.Initialize(_startShopModelStats);
        _shopView.Initialize(_shopWindow, _clickPowerButtonText, _passiveIncomeButtonText, _passiveIncomeIntervalButtonText);
        _shopPresenter.Initialize(_shopModel, _shopView, _gamePresenter);
    }

    private void OnDestroy()
    {
        _gamePresenter.OnDestroy();
        _shopPresenter.OnDestroy();
    }
}
