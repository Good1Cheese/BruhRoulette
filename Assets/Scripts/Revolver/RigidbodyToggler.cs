using UnityEngine;

public class RigidbodyToggler
{
    public RigidbodyToggler(Rigidbody rigidbody)
    {
        Rigidbody = rigidbody;
    }

    public Rigidbody Rigidbody { get; set; }

    private void Toggle(bool value)
    {
        Rigidbody.isKinematic = !value;
        Rigidbody.useGravity = value;
    }

    public void Enable()
    {
        Toggle(true);
    }

    public void Disable()
    {
        Toggle(false);
    }
}