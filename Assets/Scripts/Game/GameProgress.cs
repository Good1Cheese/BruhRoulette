using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class GameProgress : CoroutineUser
{
    [SerializeField] private float _moveTime;

    private FireButtonInputHandler _fireInputHandler;
    private PlayersList _playerList;
    private GameEnd _gameEnd;
    private WaitForSeconds _moveTimeout;

    public GamePlayer CurrentPlayer { get; set; }
    public Action MoveMade { get; set; }
    public Action<GamePlayer> CurrentNetIdUpdated { get; set; }

    [Inject]
    public void Construct(FireButtonInputHandler fireInputHandler,
                          PlayersList playersList,
                          GameEnd gameEnd)
    {
        _fireInputHandler = fireInputHandler;
        _playerList = playersList;
        _gameEnd = gameEnd;
    }

    private void Start()
    {
        _moveTimeout = new WaitForSeconds(_moveTime);

        _fireInputHandler.Handled += StartNext;
    }

    public void StartNext()
    {
        MoveMade?.Invoke();
        CurrentPlayer.IsMoveMade = true;
        StopCoroutine();

        if (_gameEnd.IsEnded) { return; }

        StartCoroutine();
    }

    public override IEnumerator Coroutine()
    {
        CurrentPlayer = _playerList.GetRandom();
        CurrentNetIdUpdated?.Invoke(CurrentPlayer);

        yield return _moveTimeout;

        StartNext();
    }

    private void OnDestroy()
    {
        _fireInputHandler.Handled -= StartNext;
    }
}