using System.Collections;
using UnityEngine;
using Zenject;

public class GameSteps : CoroutineUser
{
    [SerializeField] private float _stepDelay;

    private FireInputHandler _fireInputHandler;
    private PlayersList _playerList;
    private RouletteGame _rouletteGame;

    private int _currentPlayerIndex;
    private WaitForSeconds _stepTimeout;

    [Inject]
    public void Construct(FireInputHandler fireInputHandler, PlayersList playersList, RouletteGame rouletteGame)
    {
        _fireInputHandler = fireInputHandler;
        _playerList = playersList;
        _rouletteGame = rouletteGame;
    }

    private void Start()
    {
        _stepTimeout = new WaitForSeconds(_stepDelay);

        _rouletteGame.Started += SetFirstPlayerIndex;
        _fireInputHandler.Fired += StartWithInterrupt;
    }

    private void SetFirstPlayerIndex()
    {
        _currentPlayerIndex = Random.Range(0, _playerList.List.Count - 1) - 1;
    }

    public override IEnumerator Coroutine()
    {
        _currentPlayerIndex++;

        if (_currentPlayerIndex >= _playerList.List.Count) 
        {
            _currentPlayerIndex = 0;
        }

        _fireInputHandler.ExpectedNetId = _playerList[_currentPlayerIndex];

        yield return _stepTimeout;

        Debug.Log("Смерть");
        StartWithInterrupt();
    }

    private void OnDestroy()
    {
        _rouletteGame.Started -= SetFirstPlayerIndex;
        _fireInputHandler.Fired -= StartWithInterrupt;
    }
}