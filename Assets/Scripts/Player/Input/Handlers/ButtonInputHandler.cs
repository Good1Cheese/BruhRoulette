using System;
using Zenject;

public class ButtonInputHandler : BaseAction
{
    private GameStart _gameStart;
    private GameProgress _gameProgress;
    private GameEnd _gameEnd;

    public uint CurrentPlayerNetId { get; set; }
    public Action Handled { get; set; }
    public bool IsHandled { get; set; }

    [Inject]
    public void Construct(GameStart gameStart,
                          GameProgress gameProgress,
                          GameEnd gameEnd)
    {
        _gameStart = gameStart;
        _gameProgress = gameProgress;
        _gameEnd = gameEnd;
    }

    private void UpdateCurrentNetId(GamePlayer player)
    {
        IsHandled = false;
        CurrentPlayerNetId = player.NetId;
    }

    public void Handle(uint netId)
    {
        if (!_gameStart.IsStarted
            || _gameEnd.IsEnded
            || netId != CurrentPlayerNetId
            || IsHandled) { return; }

        IsHandled = true;
        _actionsHandler.AddInQueue(_action);
    }

    protected override void DoAction() => Handled?.Invoke();

    private void OnEnable()
    {
        _gameProgress.NextMoveStarted += UpdateCurrentNetId;
    }

    private void OnDestroy()
    {
        _gameProgress.NextMoveStarted -= UpdateCurrentNetId;
    }
}