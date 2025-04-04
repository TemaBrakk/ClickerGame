using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField] private GameView _gameView;
    [SerializeField] private InputReader _inputReader;

    private GameModel _gameModel;
    private GamePresenter _gamePresenter;


    private void Awake()
    {
        _gameModel = new GameModel(0f, 0f, 1f);

        _gameView.Initialize(_inputReader);

        _gamePresenter = new GamePresenter(_gameView, _gameModel);
    }
}
