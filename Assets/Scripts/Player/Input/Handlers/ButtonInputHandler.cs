using System;
using UnityEngine;
using Zenject;

public class ButtonInputHandler : MonoBehaviour
{
    private GameStart _gameStart;
    private GameProgress _gameProgress;
    private GameStop _gameStop;

    private bool _handled;

    public uint CurrentPlayerNetId { get; set; }
    public Action Handled { get; set; }

    [Inject]
    public void Construct(GameStart gameStart, GameProgress gameProgress, GameStop gameStop)
    {
        _gameStart = gameStart;
        _gameProgress = gameProgress;
        _gameStop = gameStop;
    }

    private void Start()
    {
        _gameProgress.CurrentNetIdUpdated += UpdateCurrentNetId;
    }

    private void UpdateCurrentNetId(uint value)
    {
        _handled = false;
        CurrentPlayerNetId = value;
    }

    public void Handle(uint netId)
    {
        if (!_gameStart.IsStarted
            || _gameStop.IsStoped
            || _handled
            || netId != CurrentPlayerNetId) { return; }

        _handled = true;
        Handled?.Invoke();
    }

    private void OnDestroy()
    {
        _gameProgress.CurrentNetIdUpdated -= UpdateCurrentNetId;
    }
}