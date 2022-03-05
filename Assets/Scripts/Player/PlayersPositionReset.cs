using UnityEngine;
using Zenject;

public class PlayersPositionReset : MonoBehaviour
{
    private Gay1[] _startPosAndRot;
    private Rigidbody[] _targetRigidbodies;

    public RagdollToggler RagdollToggler { get; set; }

    private void Start()
    {
        _targetRigidbodies = RagdollToggler.Rigidbodies;
        _startPosAndRot = new Gay1[_targetRigidbodies.Length];
        
        for (int i = 0; i < RagdollToggler.Rigidbodies.Length; i++)
        {
            Transform transform1 = RagdollToggler.Rigidbodies[i].transform;
            _startPosAndRot[i] = new Gay1(transform1.localRotation, transform1.localPosition);
        }
    }

    public void ResetPosition()
    {
        for (int i = 0; i < _targetRigidbodies.Length; i++)
        {
            var rigidbody = _targetRigidbodies[i].transform;
            var ga1 = _startPosAndRot[i];

            rigidbody.localPosition = ga1.LocalPosition;
            rigidbody.localRotation = ga1.LocalRotation;
        }
    }
}

public class Gay1
{
    public Vector3 LocalPosition { get; set; }

    public Quaternion LocalRotation { get; set; }

    public Gay1(Quaternion localRotation, Vector3 localPosition)
    {
        LocalRotation = localRotation;
        LocalPosition = localPosition;
    }
}