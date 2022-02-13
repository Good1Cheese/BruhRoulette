using Mirror;
using UnityEngine;
using Zenject;

public class PlayerFactory : PlaceholderFactory<Transform>
{
    private DiContainer _container;
    private PlayerPositionSetter _positionSetter;
    private GameObject _clientPlayer;
    private GameObject _hostPlayer;

    private Transform _newPlayer;

    [Inject]
    public void Construct(DiContainer container,
                          PlayerPositionSetter positionSetter,
                          [Inject(Id = "Client")] GameObject prefab,
                          [Inject(Id = "Host")] GameObject hostPrefab)
    {
        _container = container;
        _positionSetter = positionSetter;
        _clientPlayer = prefab;
        _hostPlayer = hostPrefab;
    }

    public override Transform Create()
    {
        _newPlayer = CreateNewPlayer().transform;
        _positionSetter.Set(_newPlayer);

        return _newPlayer;
    }

    private GameObject CreateNewPlayer()
    {
        if (NetworkServer.connections.Count <= 1)
        {
            return _container.InstantiatePrefab(_hostPlayer);
        }

        return _container.InstantiatePrefab(_clientPlayer);
    }
}