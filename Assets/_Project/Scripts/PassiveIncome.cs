using UnityEngine;

public class PassiveIncome : MonoBehaviour
{
    private GamePresenter _gamePresenter;
    private float _passiveIncome;
    private float _timeToWait = 1f;
    private float _lastTimeInvoked = 0f;

    public void SetGamePresenter(GamePresenter gamePresenter)
    {
        _gamePresenter = gamePresenter;
    }

    private void Update()
    {
        if (Time.time - _timeToWait > _lastTimeInvoked)
        {
            _lastTimeInvoked = Time.time;
            _gamePresenter.AddMoneyForPassiveIncome();
        }
    }
}
