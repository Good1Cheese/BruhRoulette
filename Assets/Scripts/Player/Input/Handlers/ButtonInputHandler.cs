using System;
using UnityEngine;
using Zenject;

public class ButtonInputHandler : MonoBehaviour
{
    private GameStart _gameStart;
    private GameProgress _gameProgress;
    private bool _isHandled;

    public uint CurrentPlayerNetId { get; set; }
    public Action Handled { get; set; }

    [Inject]
    public void Construct(GameStart gameStart, GameProgress gameProgress)
    {
        _gameStart = gameStart;
        _gameProgress = gameProgress;
    }

    private void Start()
    {
        _gameProgress.CurrentPlayerNetIdUpdated += UpdateCurrentPlayerNetId;
    }

    private void UpdateCurrentPlayerNetId(uint value)
    {
        _isHandled = false;
        CurrentPlayerNetId = value;
    }

    public void Handle(uint netId)
    {
        if (!_gameStart.GameStarted
            || netId != CurrentPlayerNetId
            || _isHandled) { return; }

        _isHandled = true;
        Handled?.Invoke();
    }

    private void OnDestroy()
    {
        _gameProgress.CurrentPlayerNetIdUpdated -= UpdateCurrentPlayerNetId;
    }
}