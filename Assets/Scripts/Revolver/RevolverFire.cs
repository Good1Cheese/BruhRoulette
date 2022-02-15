using UnityEngine;
using Zenject;

public class RevolverFire : MonoBehaviour
{
    private FireButtonInputHandler _fireInputHandler;
    private RevolverLoad _revolverLoad;

    [Inject]
    public void Construct(FireButtonInputHandler fireInputHandler, RevolverLoad revolverLoad)
    {
        _fireInputHandler = fireInputHandler;
        _revolverLoad = revolverLoad;
    }

    private void Start()
    {
        _fireInputHandler.Handled += Fire;
    }

    private void Fire()
    {
        bool cellLoaded = _revolverLoad.BulletCells.GetLast();

        if (!cellLoaded) { return; }

        Debug.Log("Смерть");
    }

    private void OnDestroy()
    {
        _fireInputHandler.Handled -= Fire;
    }
}