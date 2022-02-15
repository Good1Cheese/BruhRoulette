using Mirror;
using UnityEngine.InputSystem;

public abstract class InputGetter : NetworkBehaviour
{
    protected InputContainer _inputContainer;
    protected InputAction.CallbackContext _context;

    private void Start()
    {
        _inputContainer = GetComponent<InputContainer>();
        Subscribe();
    }

    protected void GetContext(InputAction.CallbackContext context)
    {
        if (!isLocalPlayer) { return; }

        _context = context;
        OnInputGetted();
    }


    private void OnDestroy()
    {
        Unsubscribe();
    }

    protected abstract void OnInputGetted();
    protected abstract void Subscribe();
    protected abstract void Unsubscribe();
}