using System;
using UnityEngine;
using Zenject;

public class GameEnd : MonoBehaviour
{
    private GamePlayersList _currentPlayersList;
    private GameProgress _gameProgress;
    private GameRestart _gameRestart;

    public Action Ended { get; set; }
    public bool IsEnded { get; private set; }

    [Inject]
    public void Construct(GamePlayersList currentPlayersList, GameProgress gameProgress, GameRestart gameRestart)
    {
        _currentPlayersList = currentPlayersList;
        _gameProgress = gameProgress;
        _gameRestart = gameRestart;
    }

    private void Start()
    {
        _gameProgress.MoveMade += StopGameIfNeeded;
        _gameRestart.Restarted += OnGameRestart;
    }

    private void OnGameRestart() => IsEnded = false;

    public void StopGameIfNeeded()
    {
        if (IsEnded || _currentPlayersList.List.Count > 1) { return; }

        Ended?.Invoke();
        IsEnded = true;
    }

    private void OnDestroy()
    {
        _gameProgress.MoveMade -= StopGameIfNeeded;
        _gameRestart.Restarted -= OnGameRestart;
    }
}