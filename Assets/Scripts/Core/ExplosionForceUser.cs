using Mirror;
using UnityEngine;

public class ExplosionForceUser : NetworkBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _randomSphereRadiusMultiplier;
    [SerializeField] private float _upwardsModifier;

    private Vector3 _randomPosition;

    protected void GetRandomPosition()
    {
        _randomPosition = transform.position + UnityEngine.Random.insideUnitSphere * _randomSphereRadiusMultiplier;
    }

    protected void AddExplositionForce(Rigidbody rigidbody)
    {
        rigidbody.AddExplosionForce(_explosionForce,
                                 _randomPosition,
                                 _explosionRadius,
                                 _upwardsModifier,
                                 ForceMode.Impulse);
    }
}