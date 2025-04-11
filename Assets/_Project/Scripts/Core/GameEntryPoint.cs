using UnityEngine;
using TMPro;

public class GameEntryPoint : MonoBehaviour
{
    [Header("MVP")]
    [SerializeField] private GameView _gameView;
    [SerializeField] private ShopView _shopView;
    [SerializeField] private Character _character;

    [Header("Services")]
    [SerializeField] private Updater _updater;

    [Header("UI")]
    [SerializeField] private TMP_Text _coinsText;
    [SerializeField] private GameObject _shopWindow;
    [SerializeField] private TMP_Text _clickPowerButtonText;
    [SerializeField] private TMP_Text _passiveIncomeButtonText;
    [SerializeField] private TMP_Text _passiveIncomeIntervalButtonText;

    [Header("Configs")]
    [SerializeField] private StartGameModelStats _startGameModelStats;
    [SerializeField] private StartShopModelStats _startShopModelStats;

    private GameModel _gameModel;
    private GamePresenter _gamePresenter;

    private ShopModel _shopModel;
    private ShopPresenter _shopPresenter;

    private InputReader _inputReader;


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

        _updater.Initialize();
        _updater.AddUpdatable(_inputReader);
    }

    private void InitializeGameMVP()
    {
        _gameModel = new GameModel();
        _gamePresenter = new GamePresenter();

        _gamePresenter.Initialize(_gameView, _gameModel, _character);
        _gameModel.Initialize(_startGameModelStats);
        _gameView.Initialize(_inputReader, _coinsText);

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
