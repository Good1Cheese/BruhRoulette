using UnityEngine;

public class InputContainer : MonoBehaviour
{
    private PlayerInput _input;

    public PlayerInput Input => _input;

    private void Awake()
    {
        _input = new PlayerInput();
    }

    private void OnEnable()
    {
        Input.Enable();
    }

    private void OnDisable()
    {
        Input.Disable();
    }
}