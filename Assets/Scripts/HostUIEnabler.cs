using Mirror;
using UnityEngine;
using Zenject;

public class HostUIEnabler : NetworkBehaviour
{
    [SerializeField] private GameObject _hostUI;

    private GameStep _gameStep;

    [Inject]
    public void Construct(GameStep gameStep)
    {
        _gameStep = gameStep;
    }

    public override void OnStartClient()
    {
        print(_gameStep);
        base.OnStartClient();

        if (!isServer) { return; }

        _hostUI.SetActive(true);
    }
}