using Zenject;

public class SpinButtonInputGetter : InputReveiver
{
    private SpinButtonInputHandler _handler;

    [Inject]
    public void Construct(SpinButtonInputHandler handler)
    {
        _handler = handler;
    }

    protected override void Send()
    {
        _handler.Handle(netId);
    }

    protected override void Subscribe()
    {
        _inputContainer.Input.Revolver.Scroll.performed += Receive;
    }

    protected override void Unsubscribe()
    {
        _inputContainer.Input.Revolver.Scroll.performed -= Receive;
    }
}