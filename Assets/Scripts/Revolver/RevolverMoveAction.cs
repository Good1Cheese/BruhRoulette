using UnityEngine;
using Zenject;

[RequireComponent(typeof(RevolverMove))]
public class RevolverMoveAction : RevolverAction
{
    private RevolverMove _revolverMove;
    private GameProgress _gameProgress;

    [Inject]
    public void Construct(GameProgress gameProgress)
    {
        _gameProgress = gameProgress;
    }

    private new void Awake()
    {
        base.Awake();

        _revolverMove = GetComponent<RevolverMove>();
        _revolverMove.MoveTime = _actionDelay;

        _gameProgress.CurrentNetIdUpdated += MoveNext;
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
        _gameProgress.CurrentNetIdUpdated -= MoveNext;
    }
}