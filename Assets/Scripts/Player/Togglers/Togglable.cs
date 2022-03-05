using Mirror;

public abstract class Togglable : NetworkBehaviour
{
    private PlayerTogglersEnablerDisabler _toggler;

    protected void Awake()
    {
        _toggler = GetComponent<PlayerTogglersEnablerDisabler>();
    }

    protected void OnEnable() => _toggler.Toggled += Toggle;

    protected void OnDestroy() => _toggler.Toggled -= Toggle;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        Toggle(true);
    }

    public abstract void Toggle(bool value);
}