using Mirror;
using UnityEngine;

public class ExplosionForceUser : NetworkBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _randomSphereRadiusMultiplier;
    [SerializeField] private float _upwardsModifier;

    private Vector3 _randomPosition;

    protected void AddExplositionForce(Rigidbody rigidbody)
    {
        _randomPosition = transform.position + Random.insideUnitSphere * _randomSphereRadiusMultiplier;

        rigidbody.AddExplosionForce(_explosionForce,
                                    _randomPosition,
                                    _explosionRadius,
                                    _upwardsModifier,
                                    ForceMode.Impulse);
    }
}