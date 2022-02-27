using UnityEngine;

public class InputContainer : MonoBehaviour
{
    private PlayerInput _input;
    private DelayAfterDeath _delayAfterDeath;

    public PlayerInput Input => _input;

    private void Awake()
    {
        _input = new PlayerInput();
        _delayAfterDeath = GetComponent<DelayAfterDeath>();
    }

    private void OnEnable()
    {
        Input.Enable();
        _delayAfterDeath.Done += OnDestroy;
    }

    private void OnDestroy()
    {
        Input.Disable();
        _delayAfterDeath.Done -= OnDestroy;
    }
}