using UnityEngine;
using UnityEngine.InputSystem;

public class RotationInputHandler : MonoBehaviour
{
    [SerializeField] private float _xSensivity;
    [SerializeField] private float _ySensivity;

    [SerializeField] private int _maxHorizontal;
    [SerializeField] private int _maxVertical;

    [SerializeField] private Transform _horizontalTarget;
    [SerializeField] private Transform _verticalTarget;

    private float _horizontal;
    private float _vertical;

    public void Handle(InputAction.CallbackContext context)
    {
        GetRotationFromContext(context);
        ClampRotation();

        _horizontalTarget.localRotation = Quaternion.Euler(_horizontal, 0, 0);
        _verticalTarget.localRotation = Quaternion.Euler(_vertical, 0, 0);
    }

    private void GetRotationFromContext(InputAction.CallbackContext context)
    {
        Vector2 view = context.ReadValue<Vector2>();

        _horizontal += view.x * _xSensivity * Time.deltaTime;
        _vertical += view.y * _ySensivity * Time.deltaTime;
    }

    private void ClampRotation()
    {
        _horizontal = Mathf.Clamp(_horizontal, -_maxHorizontal, _maxHorizontal);
        _vertical = Mathf.Clamp(_vertical, -_maxVertical, _maxVertical);
    }
}