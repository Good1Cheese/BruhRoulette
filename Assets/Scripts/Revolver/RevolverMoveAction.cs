using UnityEngine;
using Zenject;

[RequireComponent(typeof(RevolverMove))]
public class RevolverMoveAction : BaseAction
{
    private RevolverMove _revolverMove;
    private GameProgress _gameProgress;

    [Inject]
    public void Construct(GameProgress gameProgress, RevolverMove revolverMove, ActionsHandler actionsHandler)
    {
        _gameProgress = gameProgress;
        _revolverMove = revolverMove;
        _actionsHandler = actionsHandler;

        _revolverMove.MoveTime = _actionDelay;
    }

    private new void Awake()
    {
        base.Awake();

        _gameProgress.NextMoveStarted += PerformAction;
    }

    private void PerformAction(GamePlayer player)
    {
        _revolverMove.CurrentPlayer = player;
        _actionsHandler.AddInQueue(_action);
    }

    protected override void DoAction() => _revolverMove.StartWithInterrupt();

    private void OnDestroy()
    {
        _gameProgress.NextMoveStarted -= PerformAction;
    }
}