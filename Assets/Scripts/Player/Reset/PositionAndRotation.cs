using UnityEngine;

public struct PositionAndRotation
{
    public Vector3 LocalPosition { get; set; }

    public Quaternion LocalRotation { get; set; }

    public PositionAndRotation(Quaternion localRotation, Vector3 localPosition)
    {
        LocalRotation = localRotation;
        LocalPosition = localPosition;
    }
}