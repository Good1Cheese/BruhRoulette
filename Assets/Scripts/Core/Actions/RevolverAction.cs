using System;
using UnityEngine;
using Zenject;

public abstract class RevolverAction : MonoBehaviour, IDoneable
{
    [SerializeField] protected float _actionDelay;

    protected ActionsHandler _actionsHandler;
    protected PlayerAction _action;

    public Action Done { get; set; }
    public float ActionDelay => _actionDelay;

    [Inject]
    public void Construct(ActionsHandler actionsHandler)
    {
        _actionsHandler = actionsHandler;
    }

    protected void Awake()
    {
        _action = new PlayerAction(_actionDelay, () => DoAction());
    }

    protected void PerformAction()
    {
        _actionsHandler.StartAction(_action);
    }

    protected abstract void DoAction();
}