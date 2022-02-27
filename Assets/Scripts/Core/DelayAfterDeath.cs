using Mirror;
using System;
using System.Collections;
using UnityEngine;

public class DelayAfterDeath : NetworkBehaviour, IDoneable
{
    [SerializeField] private float _delay;

    private WaitForSeconds _timeout;

    public Action Done { get; set; }

    private void Awake()
    {
        _timeout = new WaitForSeconds(_delay);
    }

    public void StartCoroutine() => StartCoroutine(Coroutine());

    public IEnumerator Coroutine()
    {
        yield return _timeout;

        CmdInovkeAction();
    }

    [ClientRpc]
    private void CmdInovkeAction() => Done?.Invoke();
}