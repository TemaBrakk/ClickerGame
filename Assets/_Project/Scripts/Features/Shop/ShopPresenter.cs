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

        _shopView.ShopClicked += OnShopClick;
        _shopView.UpgradeClickPowerClicked += OnUpgradeClickPowerClick;
        _shopView.UpgradePassiveIncomeClicked += OnUpgradePassiveIncome;
    }

    private void OnShopClick()
    {
        if (_shopModel.IsShopWindowActive)
            _shopView.HideShopWindow();
        else
            _shopView.ShowShopWindow();

        _shopModel.IsShopWindowActive = !_shopModel.IsShopWindowActive;
    }

    private void OnUpgradeClickPowerClick()
    {
        _gamePresenter.AddClickPower();
    }

    private void OnUpgradePassiveIncome()
    {
        _gamePresenter.AddPassiveIncome();
    }

    public void OnDestroy()
    {
        _shopView.ShopClicked -= OnShopClick;
        _shopView.UpgradeClickPowerClicked -= OnUpgradeClickPowerClick;
        _shopView.UpgradePassiveIncomeClicked -= OnUpgradePassiveIncome;
    }
}
