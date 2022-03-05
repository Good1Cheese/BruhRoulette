public class InputContainer : Togglable
{
    private PlayerInput _input;

    public PlayerInput Input => _input;

    private new void Awake()
    {
        base.Awake();

        _input = new PlayerInput();
    }

    public override void Toggle(bool value)
    {
        if (value)
        {
            Input.Enable();
            return;
        }

        Input.Dispose();
    }
}