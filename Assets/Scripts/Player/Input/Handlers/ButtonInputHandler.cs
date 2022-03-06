using System;
using UnityEngine;
using Zenject;

public class ButtonInputHandler : MonoBehaviour
{
    private GameStart _gameStart;
    private GameProgress _gameProgress;
    private GameEnd _gameEnd;
    private ActionsHandler _actionsHandler;
    private bool _handled;

    public uint CurrentPlayerNetId { get; set; }
    public Action Handled { get; set; }

    [Inject]
    public void Construct(GameStart gameStart,
                          GameProgress gameProgress,
                          GameEnd gameEnd,
                          ActionsHandler actionsHandler)
    {
        _gameStart = gameStart;
        _gameProgress = gameProgress;
        _gameEnd = gameEnd;
        _actionsHandler = actionsHandler;
    }

    private void UpdateCurrentNetId(GamePlayer player)
    {
        _handled = false;
        CurrentPlayerNetId = player.NetId;
    }

    public void Handle(uint netId)
    {
        if (!_gameStart.IsStarted
            || _gameEnd.IsEnded
            || netId != CurrentPlayerNetId
            || _actionsHandler.IsActionGoing
            || _handled) { return; }

        _handled = true;
        Handled?.Invoke();
    }

    private void OnEnable()
    {
        _gameProgress.MextMoveStarted += UpdateCurrentNetId;
    }

    private void OnDestroy()
    {
        _gameProgress.MextMoveStarted -= UpdateCurrentNetId;
    }
}