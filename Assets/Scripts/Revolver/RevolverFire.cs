using UnityEngine;
using Zenject;

public class RevolverFire : MonoBehaviour
{
    private FireInputHandler _fireInputHandler;
    private RevolverLoad _revolverLoad;

    [Inject]
    public void Construct(FireInputHandler fireInputHandler, RevolverLoad revolverLoad)
    {
        _fireInputHandler = fireInputHandler;
        _revolverLoad = revolverLoad;
    }

    private void Start()
    {
        _fireInputHandler.Fired += Fire;
    }

    private void Fire()
    {
        bool cellLoaded = _revolverLoad.BulletCells.Pop();

        if (!cellLoaded) { return; }

        Debug.Log("Смерть");
    }

    private void OnDestroy()
    {
        _fireInputHandler.Fired -= Fire;
    }
}