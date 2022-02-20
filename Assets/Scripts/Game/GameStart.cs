using System;
using UnityEngine;
using Zenject;

public class GameStart : MonoBehaviour
{
    private GameProgress _gameProgress;

    public bool IsStarted { get; private set; }
    public Action Started { get; set; }

    [Inject]
    public void Construct(GameProgress gameProgress)
    {
        _gameProgress = gameProgress;
    }

    public void StartGame()
    {
        print("Game Start");
        IsStarted = true;
        Started?.Invoke();

        _gameProgress.StartCoroutine();
    }
}