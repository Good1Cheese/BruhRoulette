using UnityEngine;
using Zenject;

public abstract class RevolverSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _sound;

    private AudioSource _soundSource;
    protected IDoneable _action;

    [Inject]
    public void Construct(AudioSource soundSource)
    {
        _soundSource = soundSource;
    }

    private void Start()
    {
        _action.Done += PlaySound;
    }

    protected void PlaySound()
    {
        _soundSource.PlayOneShot(_sound);
    }

    private void OnDestroy()
    {
        _action.Done -= PlaySound;
    }
}