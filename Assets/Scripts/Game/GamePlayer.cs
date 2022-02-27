using UnityEngine;

public class GamePlayer
{
    public GamePlayer(uint netId, Transform transform, DeathPush deathPush)
    {
        NetId = netId;
        Transform = transform;
        DeathPush = deathPush;
    }

    public uint NetId { get; private set; }
    public Transform Transform { get; private set; }
    public DeathPush DeathPush { get; private set; }

    public bool IsMoveMade { get; set; }
}