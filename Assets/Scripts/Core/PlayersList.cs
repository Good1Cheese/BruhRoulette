using System.Collections.Generic;
using UnityEngine;

public class PlayersList : MonoBehaviour
{
    private readonly List<uint> _list = new List<uint>();

    public List<uint> List => _list;
    public uint this[int index] => _list[index];

    public void Add(uint netId)
    {
        _list.Add(netId);
    }
}