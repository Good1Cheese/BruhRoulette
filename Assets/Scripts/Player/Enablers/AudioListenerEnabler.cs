using Mirror;
using UnityEngine;

public class AudioListenerEnabler : NetworkBehaviour
{
    [SerializeField] private AudioListener _listener;

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        _listener.enabled = true;
    }
}