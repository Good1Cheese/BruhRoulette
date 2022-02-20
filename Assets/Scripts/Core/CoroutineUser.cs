using System.Collections;
using UnityEngine;

public abstract class CoroutineUser : MonoBehaviour
{
    private IEnumerator _enumerator;

    public virtual void StartWithInterrupt()
    {
        StopCoroutine();
        StartCoroutine();
    }

    public void StartCoroutine()
    {
        _enumerator = Coroutine();
        StartCoroutine(_enumerator);
    }

    public void StopCoroutine()
    {
        StopCoroutine(_enumerator);
    }

    public abstract IEnumerator Coroutine();
}