using System;
using UnityEngine;
using Zenject;

public class GameStop : MonoBehaviour
{
    private PlayersList _playersList;

    public Action Stoped { get; set; }
    public bool IsStoped { get; private set; }
    private bool LeftMoves => _playersList.List.Exists(move => !move.MadeMove);

    [Inject]
    public void Construct(PlayersList playersList)
    {
        _playersList = playersList;
    }

    public void StopGameIfNeeded()
    {
        if (IsStoped || LeftMoves) { return; }

        IsStoped = true;
        Stoped?.Invoke();
        print("All players made Moves. Game End");
    }
}