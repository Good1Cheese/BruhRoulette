using System;
using UnityEngine;

public class PlayerAction
{
    public PlayerAction(float delay, Action action)
    {
        Timeout = new WaitForSeconds(delay);
        Action = action;
    }

    public WaitForSeconds Timeout { get; private set; }
    public Action Action { get; private set; }
}