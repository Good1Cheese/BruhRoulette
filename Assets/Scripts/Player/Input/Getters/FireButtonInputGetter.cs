using Zenject;

public class FireButtonInputGetter : InputReveiver
{
    private FireButtonInputHandler _handler;

    [Inject]
    public void Construct(FireButtonInputHandler handler)
    {
        _handler = handler;
    }

    protected override void Send()
    {
        _handler.Handle(netId);
    }

    protected override void Subscribe()
    {
        _inputContainer.Input.Revolver.Fire.performed += Receive;
    }

    protected override void Unsubscribe()
    {
        _inputContainer.Input.Revolver.Fire.performed -= Receive;
    }
}