using Mirror;
using Zenject;

public class PlayerCounter : NetworkBehaviour
{
    private PlayersList _counter;

    [Inject]
    public void Construct(PlayersList counter)
    {
        _counter = counter;
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        AddPlayer();
    }

    [Command]
    private void AddPlayer() => _counter.Add(netId);
}