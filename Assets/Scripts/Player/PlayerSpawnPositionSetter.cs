using Mirror;
using UnityEngine;

public class PlayerSpawnPositionSetter : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;

    public Transform[] SpawnPoints => _spawnPoints;

    public void Set(Transform player)
    {
        Transform currentSpawnPoint = SpawnPoints[NetworkServer.connections.Count - 1];
        player.SetPositionAndRotation(currentSpawnPoint.position, currentSpawnPoint.rotation);
    }
}