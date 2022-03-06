using UnityEngine;

public class PlayersPositionReset : MonoBehaviour
{
    private StartPositionsAndRotations _startPositionsAndRotations;
    private Rigidbody[] _ragdollParts;

    public RagdollToggler RagdollToggler { get; set; }

    private void Start()
    {
        _ragdollParts = RagdollToggler.RagdollParts;

        _startPositionsAndRotations = new StartPositionsAndRotations(_ragdollParts.Length,
                                                                     _ragdollParts);
    }

    public void Reset()
    {
        for (int i = 0; i < _ragdollParts.Length; i++)
        {
            Transform ragdollPart = _ragdollParts[i].transform;
            var positionAndRotation = _startPositionsAndRotations[i];

            ragdollPart.localPosition = positionAndRotation.LocalPosition;
            ragdollPart.localRotation = positionAndRotation.LocalRotation;
        }
    }
}

public struct StartPositionsAndRotations
{
    private PositionAndRotation[] _startPosAndRot;

    public StartPositionsAndRotations(int lenght, Rigidbody[] rigidbodies)
    {
        _startPosAndRot = new PositionAndRotation[lenght];
        Initialize(rigidbodies);
    }

    public ref PositionAndRotation this[int index]
    {
        get => ref _startPosAndRot[index];
    }

    public void Initialize(Rigidbody[] rigidbodies)
    {
        for (int i = 0; i < rigidbodies.Length; i++)
        {
            var point = rigidbodies[i].transform;
            _startPosAndRot[i] = new PositionAndRotation(point.localRotation, point.localPosition);
        }
    }
}