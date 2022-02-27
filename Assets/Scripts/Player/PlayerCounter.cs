using Mirror;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(DeathPush))]
public class PlayerCounter : NetworkBehaviour
{
    private PlayersList _list;
    private GamePlayer _player;

    [Inject]
    public void Construct(PlayersList list)
    {
        _list = list;
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        _player = new GamePlayer(netId, transform, GetComponent<DeathPush>());
        CmdAddPlayer();
    }

    [Command]
    private void CmdAddPlayer()
    {
        _list.Add(_player);
    }
}