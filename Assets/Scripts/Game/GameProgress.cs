using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class GameProgress : CoroutineUser
{
    [SerializeField] private float _stepTime;

    private FireButtonInputHandler _fireInputHandler;
    private PlayersList _playerList;

    private int _currentPlayerIndex;
    private WaitForSeconds _stepTimeout;

    public Action<uint> CurrentPlayerNetIdUpdated { get; set; }

    [Inject]
    public void Construct(FireButtonInputHandler fireInputHandler, PlayersList playersList)
    {
        _fireInputHandler = fireInputHandler;
        _playerList = playersList;
    }

    private void Start()
    {
        _stepTimeout = new WaitForSeconds(_stepTime);

        _fireInputHandler.Handled += StartWithInterrupt;
    }

    public override void StartCoroutine()
    {
        base.StartCoroutine();
        _currentPlayerIndex = UnityEngine.Random.Range(0, _playerList.List.Count - 1) - 1;
    }

    public override IEnumerator Coroutine()
    {
        UpdatePlayerIndex();

        CurrentPlayerNetIdUpdated.Invoke(_playerList[_currentPlayerIndex]);

        yield return _stepTimeout;

        Debug.Log("Time out");
        StartWithInterrupt();
    }

    private void UpdatePlayerIndex()
    {
        _currentPlayerIndex++;

        if (_currentPlayerIndex >= _playerList.List.Count)
        {
            _currentPlayerIndex = 0;
        }
    }

    private void OnDestroy()
    {
        _fireInputHandler.Handled -= StartWithInterrupt;
    }
}