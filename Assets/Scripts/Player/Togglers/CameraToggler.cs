using Mirror;
using UnityEngine;

public class CameraToggler : Togglable
{
    [SerializeField] private Camera _camera;

    public Camera Camera => _camera;

    public override void Toggle(bool value) => _camera.enabled = value;

    private new void OnEnable()
    {
        base.OnEnable();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private new void OnDestroy()
    {
        base.OnDestroy();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}