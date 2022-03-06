using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayersReset), typeof(GamePlayersList))]
public class PlayersList : MonoBehaviour
{
    public List<GamePlayer> List { get; set; } = new List<GamePlayer>();

    public GamePlayer this[int index] => List[index];

    public void Add(GamePlayer player)
    {
        List.Add(player);
    }
}