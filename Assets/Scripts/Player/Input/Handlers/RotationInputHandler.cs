using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotationInputHandler : MonoBehaviour
{
    [SerializeField] private float _xSensivity;
    [SerializeField] private float _ySensivity;

    [SerializeField] private int _maxHorizontal;
    [SerializeField] private int _maxVertical;

    private float _horizontal;
    private float _vertical;
    private Transform _camera;

    private void Awake()
    {
        CameraEnabler cameraEnabler = GetComponent<CameraEnabler>();
        _camera = cameraEnabler.Camera.transform;
    }

    public void Handle(InputAction.CallbackContext context)
    {
        GetRotationFromContext(context);
        ClampRotation();

        _camera.localRotation = Quaternion.Euler(_vertical, _horizontal, 0);
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