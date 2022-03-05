public class GamePlayer
{
    public GamePlayer(uint netId, PlayerTogglersEnablerDisabler togglersToggle)
    {
        NetId = netId;
        TogglersToggle = togglersToggle;
    }

    public uint NetId { get; private set; }
    public PlayerTogglersEnablerDisabler TogglersToggle { get; private set; }
}