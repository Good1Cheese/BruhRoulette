using Zenject;

public class RevolverSpinSound : RevolverSoundPlayer
{
    [Inject]
    public void Construct(RevolverSpin revolverSpin)
    {
        _action = revolverSpin;
    }
}