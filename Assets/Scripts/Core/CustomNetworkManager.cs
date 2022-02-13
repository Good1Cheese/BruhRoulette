using Mirror;
using Zenject;

public class CustomNetworkManager : NetworkManager
{
    private PlayerFactory _playerFactory;

    [Inject]
    public void Construct(PlayerFactory playerFactory)
    {
        _playerFactory = playerFactory;
    }

    public override void OnServerConnect(NetworkConnection conn)
    {
        base.OnServerConnect(conn);
        SpawnNewPlayer(conn);
    }

    private void SpawnNewPlayer(NetworkConnection conn)
    {
        var newPlayer = _playerFactory.Create();
        NetworkServer.AddPlayerForConnection(conn, newPlayer.gameObject);
    }
}