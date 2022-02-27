using Mirror;
using UnityEngine;
using Zenject;

public class StartButtonPressGetter : InputGetter
{
    private Transform _camera;
    private StartButtonPressHandler _handler;

    [Inject]
    public void Construct(StartButtonPressHandler handler)
    {
        _handler = handler;
    }

    private new void Awake()
    {
        base.Awake();

        var cameraToggler = GetComponent<CameraToggler>();
        _camera = cameraToggler.Camera.transform;
    }

    protected override void OnInputGetted()
    {
        CmdHandleInput();
    }

    [Command]
    private void CmdHandleInput()
    {
        _handler.Handle(_camera.transform);
    }

    protected override void Subscribe()
    {
        _inputContainer.Input.Main.StartButtonPress.performed += GetContext;
    }

    protected override void Unsubscribe()
    {
        _inputContainer.Input.Main.StartButtonPress.performed -= GetContext;
    }
}