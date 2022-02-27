using Zenject;

public class RevolverClickSound : RevolverSoundPlayer
{
    [Inject]
    public void Construct(RevolverClick revolverClick)
    {
        _action = revolverClick;
    }
}