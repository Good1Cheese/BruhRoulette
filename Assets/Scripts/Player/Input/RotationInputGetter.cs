using UnityEngine;

[RequireComponent(typeof(InputContainer), typeof(RotationInputHandler))]
public class RotationInputGetter : InputGetter
{
    private RotationInputHandler _handler;

    private void Awake()
    {
        _handler = GetComponent<RotationInputHandler>();
    }

    protected override void OnInputGetted()
    {
        _handler.Handle(_context);
    }

    protected override void Subscribe()
    {
        _inputContainer.Input.Movement.View.performed += GetInput;
    }

    protected override void Unsubscribe()
    {
        _inputContainer.Input.Movement.View.performed -= GetInput;
    }
}