using Mirror;
using Zenject;

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

        var togglersToggle = GetComponent<PlayerTogglersEnablerDisabler>();
        _player = new GamePlayer(netId, togglersToggle);

        CmdAddPlayer();
    }

    [Command]
    private void CmdAddPlayer()
    {
        _list.Add(_player);
    }
}