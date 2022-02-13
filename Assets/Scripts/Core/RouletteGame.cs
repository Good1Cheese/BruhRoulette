using System;
using UnityEngine;
using Zenject;

public class RouletteGame : MonoBehaviour
{
    private RevolverLoad _revolverLoad;
    private GameSteps _gameSteps;

    public bool GameStarted { get; private set; }
    public Action Started { get; set; }

    [Inject]
    public void Construct(RevolverLoad revolverLoad, GameSteps gameSteps)
    {
        _revolverLoad = revolverLoad;
        _gameSteps = gameSteps;
    }

    public void StartGame()
    {
        GameStarted = true;
        Started?.Invoke();

        _gameSteps.StartCoroutine();
    }
}