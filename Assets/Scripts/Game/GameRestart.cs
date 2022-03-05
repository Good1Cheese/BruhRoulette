using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class GameRestart : CoroutineUser
{
    [SerializeField] private float _delay;

    private GameEnd _gameEnd;
    private GameStart _gameStart;
    private WaitForSeconds _timeout;

    public Action Restarted { get; set; }

    [Inject]
    public void Construct(GameEnd gameEnd, GameStart gameStart)
    {
        _gameEnd = gameEnd;
        _gameStart = gameStart;

        _timeout = new WaitForSeconds(_delay);
    }

    private void Start()
    {
        _gameEnd.Ended += StartCoroutine;
    }

    public override IEnumerator Coroutine()
    {
        yield return _timeout;

        Restarted?.Invoke();
        _gameStart.StartGame();
    }

    private void OnDestroy()
    {
        _gameEnd.Ended -= StartCoroutine;
    }
}