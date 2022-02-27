using Mirror;
using UnityEngine;

public class GameStartUIEnabler : NetworkBehaviour
{
    [SerializeField] private GameObject _hostUI;

    public override void OnStartClient()
    {
        base.OnStartClient();
        Toggle(true);
    }

    public void Toggle(bool value)
    {
        _hostUI.SetActive(value);
    }
}