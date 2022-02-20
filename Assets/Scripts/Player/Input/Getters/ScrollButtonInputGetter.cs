using Mirror;
using Zenject;

public class ScrollButtonInputGetter : InputGetter
{
    private ScrollButtonInputHandler _handler;

    [Inject]
    public void Construct(ScrollButtonInputHandler handler)
    {
        _handler = handler;
    }

    protected override void OnInputGetted() => CmdHandleInput();

    [Command]
    private void CmdHandleInput() => _handler.Handle(netId);

    protected override void Subscribe()
    {
        _inputContainer.Input.Revolver.Scroll.performed += GetContext;
    }

    protected override void Unsubscribe()
    {
        _inputContainer.Input.Revolver.Scroll.performed -= GetContext;
    }
}