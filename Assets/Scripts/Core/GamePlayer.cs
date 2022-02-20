public class GamePlayer
{
    public GamePlayer(uint netId)
    {
        NetId = netId;
    }

    public uint NetId { get; set; }
    public bool MadeMove { get; set; }
}