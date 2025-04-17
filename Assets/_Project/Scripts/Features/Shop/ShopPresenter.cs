public class ShopPresenter
{
    private ShopModel _shopModel;
    private ShopView _shopView;

    private GamePresenter _gamePresenter;

    public void Initialize(ShopModel shopModel,
                           ShopView shopView,
                           GamePresenter gamePresenter)
    {
        _shopModel = shopModel;
        _shopView = shopView;
        _gamePresenter = gamePresenter;

        SubscribeToViewEvents();

        UpdateView();

        _shopView.ResetShopWindowPosition();
    }

    private void SubscribeToViewEvents()
    {
        _shopView.ShopClicked += OnShopClick;
        _shopView.UpgradeClickPowerClicked += OnUpgradeClickPowerClick;
        _shopView.UpgradePassiveIncomeClicked += OnUpgradePassiveIncome;
        _shopView.UpgradePassiveIncomeIntervalClicked += OnUpgradePassiveIncomeInterval;
    }

    private void UpdateView()
    {
        _shopView.UpdateClickPowerButton(_shopModel.ClickPowerNextLevel,
                                         _shopModel.ClickPowerUpgradeCost);

        _shopView.UpdatePassiveIncomeButton(_shopModel.PassiveIncomeNextLevel,
                                            _shopModel.PassiveIncomeUpgradeCost);

        _shopView.UpdatePassiveIncomeIntervalButton(_shopModel.PassiveIncomeIntervalNextLevel,
                                                    _shopModel.PassiveIncomeIntervalUpgradeCost);
    }

    private void OnShopClick()
    {
        if (_shopModel.IsShopWindowActive)
            _shopView.HideShopWindow();
        else
            _shopView.ShowShopWindow();

        _shopModel.ChangeShopWindowMode();
    }

    private void OnUpgradeClickPowerClick()
    {
        if (_gamePresenter.TryUpgradeClickPower(_shopModel.ClickPowerUpgradeCost))
        {
            _shopModel.AddClickPowerUpgradeCost();
            _shopView.UpdateClickPowerButton(_shopModel.ClickPowerNextLevel,
                                             _shopModel.ClickPowerUpgradeCost);
        }
    }

    private void OnUpgradePassiveIncome()
    {
        if (_gamePresenter.TryUpgradePassiveIncome(_shopModel.PassiveIncomeUpgradeCost))
        {
            _shopModel.AddPassiveIncomeUpgradeCost();
            _shopView.UpdatePassiveIncomeButton(_shopModel.PassiveIncomeNextLevel,
                                             _shopModel.PassiveIncomeUpgradeCost);
        }
    }

    private void OnUpgradePassiveIncomeInterval()
    {
        if (_gamePresenter.TryUpgradePassiveIncomeInterval(_shopModel.PassiveIncomeIntervalUpgradeCost))
        {
            _shopModel.AddPassiveIncomeIntervalUpgradeCost();
            _shopView.UpdatePassiveIncomeIntervalButton(_shopModel.PassiveIncomeIntervalNextLevel,
                                             _shopModel.PassiveIncomeIntervalUpgradeCost);
        }
    }

    public void OnDestroy()
    {
        _shopView.ShopClicked -= OnShopClick;
        _shopView.UpgradeClickPowerClicked -= OnUpgradeClickPowerClick;
        _shopView.UpgradePassiveIncomeClicked -= OnUpgradePassiveIncome;
        _shopView.UpgradePassiveIncomeIntervalClicked -= OnUpgradePassiveIncomeInterval;
    }
}
