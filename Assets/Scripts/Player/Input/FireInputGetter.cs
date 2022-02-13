using UnityEngine;
using Zenject;

[RequireComponent(typeof(InputContainer))]
public class FireInputGetter : InputGetter
{
    private FireInputHandler _handler;

    [Inject]
    public void Construct(FireInputHandler handler)
    {
        _handler = handler;
    }

    protected override void OnInputGetted()
    {
        _handler.Handle(netId);
    }

    protected override void Subscribe()
    {
        _inputContainer.Input.Movement.Fire.performed += GetInput;
    }

    protected override void Unsubscribe()
    {
        _inputContainer.Input.Movement.Fire.performed -= GetInput;
    }
}