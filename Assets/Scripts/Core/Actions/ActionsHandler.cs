using System.Collections;

public class ActionsHandler : NonInterruptableCoroutineUser
{
    private PlayerAction _currentAction;

    public void StartAction(PlayerAction playerAction)
    {
        _currentAction = playerAction;
        StartWithoutInterrupt();
    }

    public override IEnumerator Coroutine()
    {
        _currentAction.Action();

        yield return _currentAction.Timeout;
        IsActionGoing = false;
    }
}