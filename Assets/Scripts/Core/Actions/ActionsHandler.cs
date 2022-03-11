using System.Collections;
using System.Collections.Generic;

public class ActionsHandler : NonInterruptableCoroutineUser
{
    private readonly Queue<PlayerAction> _queue = new Queue<PlayerAction>();
    private PlayerAction _action;

    private PlayerAction CurrentAction
    {
        get
        {
            if (_queue.Count > 0)
            {
                return _queue.Dequeue();
            }

            return null;
        }
    }

    public void AddInQueue(PlayerAction action)
    {
        _queue.Enqueue(action);

        if (IsActionGoing) { return; }

        StartCoroutine();
    }

    public override IEnumerator Coroutine()
    {
        _action.Action?.Invoke();

        yield return _action.Timeout;

        StartCoroutine();
    }

    public override void StartCoroutine()
    {
        _action = CurrentAction;

        if (_action == null) 
        {
            IsActionGoing = false;
            return;
        }

        base.StartCoroutine();
    }
}