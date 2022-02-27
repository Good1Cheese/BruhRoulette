using System;
using UnityEngine;

public class DeathPush : ExplosionForceUser
{
    private Rigidbody[] _rigidbodies;
    private DelayAfterDeath _cameraDisabler;

    private void Awake()
    {
        _cameraDisabler = GetComponent<DelayAfterDeath>();
    }

    public void Push()
    {
        ActivateRagdoll();
        AddForce();

        _cameraDisabler.StartCoroutine();
    }

    private void ActivateRagdoll()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();

        DoActionWithRigigbodies(rigigbody =>
        {
            rigigbody.isKinematic = false;
            rigigbody.useGravity = true;
        });
    }

    private void AddForce()
    {
        GetRandomPosition();
        DoActionWithRigigbodies(rigidbody => AddExplositionForce(rigidbody));
    }

    private void DoActionWithRigigbodies(Action<Rigidbody> action)
    {
        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            action(_rigidbodies[i]);
        }
    }
}