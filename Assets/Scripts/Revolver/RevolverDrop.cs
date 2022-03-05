using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class RevolverDrop : ExplosionForceUser
{
    private GameEnd _gameEnd;
    private GameRestart _gameRestart;

    private RigidbodyToggler _rigidbodyToggler;

    [Inject]
    public void Construct(GameEnd gameEnd, GameRestart gameRestart)
    {
        _gameEnd = gameEnd;
        _gameRestart = gameRestart;

        _rigidbodyToggler = new RigidbodyToggler(GetComponent<Rigidbody>());
    }

    private void Start()
    {
        _gameRestart.Restarted += _rigidbodyToggler.Disable;
        _gameEnd.Ended += Drop;
    }

    private void Drop()
    {
        _rigidbodyToggler.Enable();
        AddExplositionForce(_rigidbodyToggler.Rigidbody);
    }

    private void OnDestroy()
    {
        _gameRestart.Restarted -= _rigidbodyToggler.Disable;
        _gameEnd.Ended -= Drop;
    }
}