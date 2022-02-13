using Mirror;
using UnityEngine;

public class PlayerPositionSetter : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;

    public void Set(Transform player)
    {
        var currentSpawnPoint = _spawnPoints[NetworkServer.connections.Count - 1];
        player.SetPositionAndRotation(currentSpawnPoint.position, currentSpawnPoint.rotation);
    }
}