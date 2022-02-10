using UnityEngine;
using UnityEngine.InputSystem;

public class NewRotator : MonoBehaviour
{
    [SerializeField] private float _xSensivity;
    [SerializeField] private float _ySensivity;

    [SerializeField] private int _verticalUpperLimit;
    [SerializeField] private int _horizontalUpperLimit;

    private PlayerInput _playerInput;

    private float _horizontal;
    private float _vertical;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }

    private void Start()
    {
        _playerInput.Movement.View.performed += context => Rotate(context);
    }

    private void Rotate(InputAction.CallbackContext context)
    {
        var view = context.ReadValue<Vector2>();

        _horizontal += view.x * _xSensivity * Time.deltaTime;
        _vertical += view.y * _ySensivity * Time.deltaTime;

        _vertical = Mathf.Clamp(_vertical, -_verticalUpperLimit, _verticalUpperLimit);
        _horizontal = Mathf.Clamp(_horizontal, -_horizontalUpperLimit, _horizontalUpperLimit);

        Quaternion targetRotation = Quaternion.Euler(_vertical, _horizontal, 0);

        transform.localRotation = targetRotation;
    }
}