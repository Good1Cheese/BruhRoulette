using Mirror;
using UnityEngine;

public class GameStartUIToggler : NetworkBehaviour
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