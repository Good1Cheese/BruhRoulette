using System.Collections.Generic;
using UnityEngine;

public class PlayersList : MonoBehaviour
{
    public List<GamePlayer> List { get; set; } = new List<GamePlayer>();

    public void Add(GamePlayer player)
    {
        List.Add(player);
    }

    public GamePlayer GetRandom()
    {
        int randomIndex = Random.Range(0, List.Count);
        GamePlayer result = List[randomIndex];

        List.Remove(result);

        return result;
    }
}