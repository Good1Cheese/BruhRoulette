using Mirror;
using System;
using UnityEngine;

[RequireComponent(typeof(DeathEffectActivator))]
public class RagdollToggler : NetworkBehaviour
{
    private PlayersPositionReset _playersPositionReset;

    public Action Enabled { get; set; }
    public Rigidbody[] Rigidbodies { get; private set; }

    private void Awake()
    {
        Rigidbodies = GetComponentsInChildren<Rigidbody>();

        _playersPositionReset = GetComponent<PlayersPositionReset>();
        _playersPositionReset.RagdollToggler = this;
    }

    public void Toggle(bool value)
    {
        value = !value;

        DoActionWithRigigbodies(rigigbody =>
        {
            rigigbody.isKinematic = !value;
            rigigbody.useGravity = value;
        });

        if (value)
        {
            Enabled?.Invoke();
            return;
        }

        _playersPositionReset.ResetPosition();
    }

    public void DoActionWithRigigbodies(Action<Rigidbody> action)
    {
        for (int i = 0; i < Rigidbodies.Length; i++)
        {
            action(Rigidbodies[i]);
        }
    }
}