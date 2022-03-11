using System;
using UnityEngine;
using Zenject;

public abstract class BaseAction : MonoBehaviour, IDoneable
{
    [SerializeField] protected float _actionDelay;

    protected ActionsHandler _actionsHandler;
    protected PlayerAction _action;

    public Action Done { get; set; }

    [Inject]
    public void Construct(ActionsHandler actionsHandler)
    {
        _actionsHandler = actionsHandler;
    }

    protected void Awake()
    {
        _action = new PlayerAction(_actionDelay, () => DoAction());
    }

    protected abstract void DoAction();
}