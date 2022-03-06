public class GamePlayer
{
    public GamePlayer(uint netId, TogglersEnablerDisabler togglersToggle)
    {
        NetId = netId;
        TogglersToggle = togglersToggle;
    }

    public uint NetId { get; private set; }
    public TogglersEnablerDisabler TogglersToggle { get; private set; }
}