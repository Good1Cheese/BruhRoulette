using UnityEngine;
using Zenject;

public class RevolverFire : MonoBehaviour
{
    private RevolverLoad _revolverLoad;

    [Inject]
    public void Construct(RevolverLoad revolverLoad)
    {
        _revolverLoad = revolverLoad;
    }

    public void Fire()
    {
        bool cellLoaded = _revolverLoad.RevolverCells.GetLast();

        if (cellLoaded)
        {
            print("Current Player fired. He is DEAD");
            return;
        }

        print("Current Player fired. He is ALIVE");
    }
}