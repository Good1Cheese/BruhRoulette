using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(RevolverShotSound), typeof(RevolverClickSound))]
public class RevolverFire : MonoBehaviour, IDoneable
{
    private RevolverLoad _revolverLoad;
    private GameProgress _gameProgress;
    private RevolverShot _revolverShot;
    private RevolverClick _revolverClick;
    private FireButtonInputHandler _inputHandler;

    public Action Done { get; set; }

    [Inject]
    public void Construct(RevolverLoad revolverLoad,
                          GameProgress gameProgress,
                          RevolverShot revolverShot,
                          RevolverClick revolverClick, 
                          FireButtonInputHandler fireButtonInputHandler)
    {
        _revolverLoad = revolverLoad;
        _gameProgress = gameProgress;
        _revolverShot = revolverShot;
        _revolverClick = revolverClick;
        _inputHandler = fireButtonInputHandler;
    }

    private void Awake()
    {
        _inputHandler.Handled += Fire;
    }

    private void Fire()
    {
        bool cellLoaded = _revolverLoad.RevolverCells.GetLast();

        if (cellLoaded)
        {
            _revolverShot.Done?.Invoke();
            _gameProgress.CurrentPlayer.TogglersToggle.RpcToggle(false);

            return;
        }

        _revolverClick.Done?.Invoke();
    }

    private void OnDestroy()
    {
        _inputHandler.Handled -= Fire;
    }
}