using UnityEngine;
using Mirror;

public class CameraEnabler : NetworkBehaviour
{
    [SerializeField] private Camera _camera;

    public override void OnStartLocalPlayer()
    {
        _camera.enabled = true;
        base.OnStartLocalPlayer();
    }
}