using UnityEngine;
using Zenject;

[RequireComponent(typeof(RevolverSpinSound))]
public class RevolverSpin : RevolverAction
{
    [SerializeField] private int _maxScrollAmount;
    [SerializeField] private int _minScrollAmount;

    private SpinButtonInputHandler _spinInputHandler;
    private RevolverLoad _revolverLoad;

    [Inject]
    public void Construct(SpinButtonInputHandler spinButtonInputHandler, RevolverLoad revolverLoad)
    {
        _spinInputHandler = spinButtonInputHandler;
        _revolverLoad = revolverLoad;
    }

    private void Start()
    {
        _spinInputHandler.Handled += PerformAction;
    }

    protected override void DoAction()
    {
        Done?.Invoke();
        int scrollCount = Random.Range(_minScrollAmount, _maxScrollAmount);

        for (int i = 0; i < scrollCount; i++)
        {
            _revolverLoad.RevolverCells.Scroll();
        }
    }

    private void OnDestroy()
    {
        _spinInputHandler.Handled -= PerformAction;
    }
}