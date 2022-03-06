using UnityEngine;

[RequireComponent(typeof(InputContainer), typeof(RotationInputHandler))]
public class RotationInputGetter : InputGetter
{
    private RotationInputHandler _handler;

    private new void Awake()
    {
        base.Awake();

        _handler = GetComponent<RotationInputHandler>();
    }

    protected override void OnInputGetted()
    {
        if (!isLocalPlayer) { return; }

        _handler.Handle(_context);
    }

    protected override void Subscribe()
    {
        _inputContainer.Input.Main.View.performed += GetContext;
    }

    protected override void Unsubscribe()
    {
        _inputContainer.Input.Main.View.performed -= GetContext;
    }
}