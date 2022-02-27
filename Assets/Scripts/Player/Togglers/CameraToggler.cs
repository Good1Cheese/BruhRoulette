using Mirror;
using UnityEngine;

public class CameraToggler : NetworkBehaviour
{
    [SerializeField] private Camera _camera;

    private DelayAfterDeath _delayAfterDeath;

    public Camera Camera => _camera;

    private void Awake()
    {
        _delayAfterDeath = GetComponent<DelayAfterDeath>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public override void OnStartLocalPlayer()
    {
        Enable();
        base.OnStartLocalPlayer();
    }

    private void Enable() => Camera.enabled = true;
    private void Disable() => Camera.enabled = false;

    private void OnEnable()
    {
        _delayAfterDeath.Done += Disable;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDestroy()
    {
        _delayAfterDeath.Done -= Disable;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}