using Zenject;

public class RevolverShotSound : RevolverSoundPlayer
{
    [Inject]
    public void Construct(RevolverShot revolverShot)
    {
        _action = revolverShot;
    }
}