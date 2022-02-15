using Mirror;
using UnityEngine;

public class CameraEnabler : NetworkBehaviour
{
    [SerializeField] private Camera _camera;

    public Camera Camera => _camera;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public override void OnStartLocalPlayer()
    {
        Camera.enabled = true;
        base.OnStartLocalPlayer();
    }
}