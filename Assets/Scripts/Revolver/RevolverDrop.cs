using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class RevolverDrop : ExplosionForceUser
{
    private GameEnd _gameEnd;
    private Rigidbody _rigidbody;

    [Inject]
    public void Construct(GameEnd gameEnd)
    {
        _gameEnd = gameEnd;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _gameEnd.Ended += Drop;
    }

    private void Drop()
    {
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;

        GetRandomPosition();
        AddExplositionForce(_rigidbody);
    }

    private void OnDestroy()
    {
        _gameEnd.Ended -= Drop;
    }
}