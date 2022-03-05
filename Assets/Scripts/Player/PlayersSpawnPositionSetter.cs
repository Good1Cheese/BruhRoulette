using Mirror;
using UnityEngine;

//[RequireComponent(typeof(PlayersPositionReset))]
public class PlayersSpawnPositionSetter : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;

    public Transform[] SpawnPoints => _spawnPoints;

    public void Set(Transform player)
    {
        Transform currentSpawnPoint = SpawnPoints[NetworkServer.connections.Count - 1];
        player.SetPositionAndRotation(currentSpawnPoint.position, currentSpawnPoint.rotation);
    }
}