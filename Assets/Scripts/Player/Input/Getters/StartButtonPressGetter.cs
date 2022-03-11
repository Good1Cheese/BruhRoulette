using UnityEngine;
using Zenject;

public class StartButtonPressGetter : InputReveiver
{
    private StartButtonPressHandler _handler;
    private Transform _camera;

    [Inject]
    public void Construct(StartButtonPressHandler handler)
    {
        _handler = handler;
    }

    private void Start()
    {
        _camera = GetComponent<CameraToggler>().Camera.transform;
    }

    protected override void Send()
    {
        _handler.Handle(_camera);
    }

    protected override void Subscribe()
    {
        _inputContainer.Input.Main.StartButtonPress.performed += Receive;
    }

    protected override void Unsubscribe()
    {
        _inputContainer.Input.Main.StartButtonPress.performed -= Receive;
    }
}