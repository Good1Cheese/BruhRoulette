using System;
using UnityEngine;
using Zenject;

public class GameEnd : MonoBehaviour
{
    private PlayersList _playersList;
    private GameProgress _gameProgress;

    public Action Ended { get; set; }
    public bool IsEnded { get; private set; }
    private bool LeftMoves => _playersList.List.Exists(move => !move.IsMoveMade);

    [Inject]
    public void Construct(PlayersList playersList, GameProgress gameProgress)
    {
        _playersList = playersList;
        _gameProgress = gameProgress;
    }

    private void Start()
    {
        _gameProgress.MoveMade += StopGameIfNeeded;
    }

    public void StopGameIfNeeded()
    {
        if (IsEnded || LeftMoves) { return; }

        Ended?.Invoke();
        IsEnded = true;
    }

    private void OnDestroy()
    {
        _gameProgress.MoveMade -= StopGameIfNeeded;
    }
}