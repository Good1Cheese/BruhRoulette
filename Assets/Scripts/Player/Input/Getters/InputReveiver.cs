using Mirror;
using UnityEngine.InputSystem;

public abstract class InputReveiver : NetworkBehaviour
{
    protected InputContainer _inputContainer;

    protected void Awake()
    {
        _inputContainer = GetComponent<InputContainer>();
    }

    protected virtual void Receive(InputAction.CallbackContext context)
    {
        if (!isLocalPlayer) { return; }

        CmdSend();
    }

    [Command]
    protected virtual void CmdSend()
    {
        Send();
    }

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    protected abstract void Send();
    protected abstract void Subscribe();
    protected abstract void Unsubscribe();
}