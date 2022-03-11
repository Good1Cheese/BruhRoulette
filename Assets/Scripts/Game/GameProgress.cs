using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class GameProgress : CoroutineUser
{
    [SerializeField] private float _moveTime;

    private FireButtonInputHandler _fireInputHandler;
    private GamePlayersList _currentPlayersList;
    private GameEnd _gameEnd;

    private WaitForSeconds _moveTimeout;

    public GamePlayer CurrentPlayer { get; set; }
    public Action MoveMade { get; set; }
    public Action<GamePlayer> NextMoveStarted { get; set; }

    [Inject]
    public void Construct(FireButtonInputHandler fireInputHandler,
                          GamePlayersList currentPlayersList,
                          GameEnd gameEnd)
    {
        _fireInputHandler = fireInputHandler;
        _currentPlayersList = currentPlayersList;
        _gameEnd = gameEnd;

        _moveTimeout = new WaitForSeconds(_moveTime);
    }

    private void Start()
    {
        _fireInputHandler.Handled += StartNext;
    }

    public void StartNext()
    {
        if (!_fireInputHandler.IsHandled) { return; }

        MoveMade?.Invoke();
        StopCoroutine();

        if (_gameEnd.IsEnded) { return; }

        StartCoroutine();
    }

    public override IEnumerator Coroutine()
    {
        CurrentPlayer = _currentPlayersList.GetRandom();
        NextMoveStarted?.Invoke(CurrentPlayer);

        yield return _moveTimeout;

        _fireInputHandler.Handle(CurrentPlayer.NetId);
    }

    private void OnDestroy()
    {
        _fireInputHandler.Handled -= StartNext;
    }
}