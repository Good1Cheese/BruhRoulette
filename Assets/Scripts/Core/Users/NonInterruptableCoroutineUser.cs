public abstract class NonInterruptableCoroutineUser : CoroutineUser
{
    public bool IsActionGoing { get; protected set; }

    public void StartWithoutInterrupt()
    {
        if (IsActionGoing) { return; }

        StartCoroutine();
    }

    public override void StartCoroutine()
    {
        IsActionGoing = true;
        base.StartCoroutine();
    }

    protected override void StopCoroutine()
    {
        IsActionGoing = false;
        base.StopCoroutine();
    }
}