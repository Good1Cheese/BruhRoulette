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

    private void Awake()
    {
        CameraEnabler cameraEnabler = GetComponent<CameraEnabler>();
        _camera = cameraEnabler.Camera.transform;
    }

    protected override void OnInputGetted()
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