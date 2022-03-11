using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(RevolverSpinSound))]
public class RevolverSpin : MonoBehaviour, IDoneable
{
    [SerializeField] private int _maxScrollAmount;
    [SerializeField] private int _minScrollAmount;

    private SpinButtonInputHandler _inputHandler;
    private RevolverLoad _revolverLoad;

    public Action Done { get; set; }

    [Inject]
    public void Construct(SpinButtonInputHandler spinButtonInputHandler, RevolverLoad revolverLoad)
    {
        _inputHandler = spinButtonInputHandler;
        _revolverLoad = revolverLoad;
    }

    private void Start()
    {
        _inputHandler.Handled += Spin;
    }

    protected void Spin()
    {
        Done?.Invoke();

        int scrollCount = UnityEngine.Random.Range(_minScrollAmount, _maxScrollAmount);

        for (int i = 0; i < scrollCount; i++)
        {
            _revolverLoad.RevolverCells.Scroll();
        }
    }

    private void OnDestroy()
    {
        _inputHandler.Handled -= Spin;
    }
}