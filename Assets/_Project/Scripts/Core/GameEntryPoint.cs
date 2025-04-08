using UnityEngine;
using TMPro;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField] private GameView _gameView;
    [SerializeField] private ShopView _shopView;

    [SerializeField] private InputReader _inputReader;
    [SerializeField] private TMP_Text _coinsText;
    [SerializeField] private GameObject _shopWindow;
    [SerializeField] private PassiveIncome _passiveIncome;

    private GameModel _gameModel;
    private GamePresenter _gamePresenter;

    private ShopModel _shopModel;
    private ShopPresenter _shopPresenter;


    private void Awake()
    {
        InitializeGameMVP();
        InitializeShopMVP();
    }

    private void InitializeGameMVP()
    {
        _gameModel = new GameModel();
        _gamePresenter = new GamePresenter();

        _gameModel.Initialize(0f, 1f, 0f);
        _gameView.Initialize(_inputReader, _coinsText);
        _gamePresenter.Initialize(_gameView, _gameModel);

        _passiveIncome.SetGamePresenter(_gamePresenter);
    }

    private void InitializeShopMVP()
    {
        _shopModel = new ShopModel();
        _shopPresenter = new ShopPresenter();

        _shopModel.Initialize();
        _shopView.Initialize(_shopWindow);
        _shopPresenter.Initialize(_shopModel, _shopView, _gamePresenter);
    }

    private void OnDestroy()
    {
        _gamePresenter.OnDestroy();
        _shopPresenter.OnDestroy();
    }
}
