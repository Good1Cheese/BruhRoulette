using Mirror;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(InputContainer))]
public class FireButtonInputGetter : InputGetter
{
    private FireButtonInputHandler _handler;

    [Inject]
    public void Construct(FireButtonInputHandler handler)
    {
        _handler = handler;
    }

    protected override void OnInputGetted() => CmdHandleInput();

    [Command]
    private void CmdHandleInput() => _handler.Handle(netId);

    protected override void Subscribe()
    {
        _inputContainer.Input.Revolver.Fire.performed += GetContext;
    }

    protected override void Unsubscribe()
    {
        _inputContainer.Input.Revolver.Fire.performed -= GetContext;
    }
}