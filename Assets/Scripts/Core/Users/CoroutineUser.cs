using System.Collections;
using UnityEngine;

public abstract class CoroutineUser : MonoBehaviour
{
    private IEnumerator _enumerator;

    protected void Awake()
    {
        _enumerator = Coroutine();
    }

    public virtual void StartWithInterrupt()
    {
        StopCoroutine();
        StartCoroutine();
    }

    public virtual void StartCoroutine()
    {
        _enumerator = Coroutine();
        StartCoroutine(_enumerator);
    }

    protected virtual void StopCoroutine()
    {
        StopCoroutine(_enumerator);
    }

    public abstract IEnumerator Coroutine();
}