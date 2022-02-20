using Mirror;
using UnityEngine;
using Zenject;

public class PlayerFactory : IFactory<Transform>
{
    private DiContainer _container;
    private PlayerSpawnPositionSetter _spawnPositionSetter;
    private GameObject _clientPrefab;
    private GameObject _hostPrefab;

    private Transform _newPlayer;

    public PlayerFactory(DiContainer container,
                          PlayerSpawnPositionSetter spawnPositionSetter,
                          [Inject(Id = "Client")] GameObject clientprefab,
                          [Inject(Id = "Host")] GameObject hostPrefab)
    {
        _container = container;
        _spawnPositionSetter = spawnPositionSetter;
        _clientPrefab = clientprefab;
        _hostPrefab = hostPrefab;
    }

    public Transform Create()
    {
        _newPlayer = CreateNewPlayer().transform;
        _spawnPositionSetter.Set(_newPlayer);

        return _newPlayer;
    }

    private GameObject CreateNewPlayer()
    {
        if (NetworkServer.connections.Count <= 1)
        {
            return _container.InstantiatePrefab(_hostPrefab);
        }

        return _container.InstantiatePrefab(_clientPrefab);
    }
}