using UnityEngine;
using Zenject;

public class RevolverScroll : MonoBehaviour
{
    [SerializeField] private int _maxScrollAmount;
    [SerializeField] private int _minScrollAmount;

    private ScrollButtonInputHandler _scrollInputHandler;
    private RevolverLoad _revolverLoad;

    [Inject]
    public void Construct(ScrollButtonInputHandler scrollButtonInputHandler, RevolverLoad revolverLoad)
    {
        _scrollInputHandler = scrollButtonInputHandler;
        _revolverLoad = revolverLoad;
    }

    private void Start()
    {
        _scrollInputHandler.Handled += Scroll;
    }

    private void Scroll()
    {
        int scrollCount = Random.Range(_minScrollAmount, _maxScrollAmount);

        for (int i = 0; i < scrollCount; i++)
        {
            _revolverLoad.BulletCells.Scroll();
        }
    }

    private void OnDestroy()
    {
        _scrollInputHandler.Handled -= Scroll;
    }
}