using Mirror;
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CameraToggler), typeof(InputContainer))]
public class TogglersEnablerDisabler : NetworkBehaviour
{
    [SerializeField] private float _delay;

    private WaitForSeconds _timeout;
    private bool _toggled;

    public Action<bool> Toggled { get; set; }
    public RagdollToggler RagdollToggler { get; set; }

    private void Awake()
    {
        _timeout = new WaitForSeconds(_delay);

        RagdollToggler = GetComponent<RagdollToggler>();
    }

    [TargetRpc]
    public void RpcToggle(bool value)
    {
        _toggled = value;
        StartCoroutine(Coroutine());
    }

    [TargetRpc]
    public void RpcToggleWithoutDelay(bool value)
    {
        RagdollToggler.Toggle(value);
        Toggled.Invoke(value);
    }

    private IEnumerator Coroutine()
    {
        RagdollToggler.Toggle(_toggled);

        yield return _timeout;

        Toggled.Invoke(_toggled);
    }
}