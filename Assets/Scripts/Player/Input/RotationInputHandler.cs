using UnityEngine;
using UnityEngine.InputSystem;

public class RotationInputHandler : MonoBehaviour
{
    [SerializeField] private float _xSensivity;
    [SerializeField] private float _ySensivity;

    private float _horizontal;
    private float _vertical;

    public void Handle(InputAction.CallbackContext context)
    {
        GetRotation(context);
        transform.localRotation = Quaternion.Euler(_vertical, _horizontal, 0);
    }

    private void GetRotation(InputAction.CallbackContext context)
    {
        var view = context.ReadValue<Vector2>();

        _horizontal += view.x * _xSensivity * Time.deltaTime;
        _vertical += view.y * _ySensivity * Time.deltaTime;
    }
}