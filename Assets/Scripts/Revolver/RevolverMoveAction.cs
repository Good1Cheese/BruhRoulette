using UnityEngine;
using Zenject;

[RequireComponent(typeof(RevolverMove))]
public class RevolverMoveAction : RevolverAction
{
    private RevolverMove _revolverMove;
    private GameProgress _gameProgress;

    [Inject]
    public void Construct(GameProgress gameProgress, RevolverMove revolverMove)
    {
        _gameProgress = gameProgress;

        _revolverMove = revolverMove;
        _revolverMove.MoveTime = _actionDelay;
    }

    private new void Awake()
    {
        base.Awake();

        _gameProgress.MextMoveStarted += MoveNext;
    }

    private void MoveNext(GamePlayer player)
    {
        _revolverMove.CurrentPlayer = player;
        PerformAction();
    }

    protected override void DoAction()
    {
        _revolverMove.StartWithInterrupt();
    }

    private void OnDestroy()
    {
        _gameProgress.MextMoveStarted -= MoveNext;
    }
}