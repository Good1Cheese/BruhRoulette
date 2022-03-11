using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(InputContainer), typeof(RotationInputHandler))]
public class RotationInputGetter : InputReveiver
{
    private InputAction.CallbackContext _context;
    private RotationInputHandler _handler;

    private void Start()
    {
        _handler = GetComponent<RotationInputHandler>();
    }

    protected override void Receive(InputAction.CallbackContext context)
    {
        _context = context;
        base.Receive(context);
    }

    protected override void CmdSend() => Send();
    protected override void Send() => _handler.Handle(_context);

    protected override void Subscribe()
    {
        _inputContainer.Input.Main.View.performed += Receive;
    }

    protected override void Unsubscribe()
    {
        _inputContainer.Input.Main.View.performed -= Receive;
    }
}