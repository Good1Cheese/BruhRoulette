using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class GameProgress : CoroutineUser
{
    [SerializeField] private float _moveTime;

    private FireButtonInputHandler _fireInputHandler;
    private PlayersList _playerList;
    private GameStop _gameStop;
    private RevolverFire _revolverFire;
    private WaitForSeconds _moveTimeout;
    private GamePlayer _currentPlayer;

    public Action<uint> CurrentNetIdUpdated { get; set; }

    [Inject]
    public void Construct(FireButtonInputHandler fireInputHandler,
                          PlayersList playersList,
                          GameStop gameStop,
                          RevolverFire revolverFire)
    {
        _fireInputHandler = fireInputHandler;
        _playerList = playersList;
        _gameStop = gameStop;
        _revolverFire = revolverFire;
    }

    private void Start()
    {
        _moveTimeout = new WaitForSeconds(_moveTime);

        _fireInputHandler.Handled += StartNext;
    }

    public void StartNext()
    {
        _currentPlayer.MadeMove = true;
        _revolverFire.Fire();
        _gameStop.StopGameIfNeeded();

        if (_gameStop.IsStoped) { return; }

        StartWithInterrupt();
    }

    public override IEnumerator Coroutine()
    {
        _currentPlayer = _playerList.GetRandom();

        print($"Now is turn player with ID - {_currentPlayer.NetId}");

        CurrentNetIdUpdated?.Invoke(_currentPlayer.NetId);

        yield return _moveTimeout;

        print($"Move time finished on player with ID - {_currentPlayer.NetId}");
        StartWithInterrupt();
    }

    private void OnDestroy()
    {
        _fireInputHandler.Handled -= StartNext;
    }
}