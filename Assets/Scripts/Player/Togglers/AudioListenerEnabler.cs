using Mirror;
using UnityEngine;

public class AudioListenerEnabler : NetworkBehaviour
{
    [SerializeField] private AudioListener _listener;

    public override void OnStartLocalPlayer()
    {
        _listener.enabled = true;
        base.OnStartLocalPlayer();
    }
}