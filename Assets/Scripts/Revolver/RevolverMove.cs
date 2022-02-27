using System.Collections;
using UnityEngine;

public class RevolverMove : CoroutineUser
{
    [SerializeField] private float _rotateSmoothing;
    [SerializeField] private Transform[] _points;

    private Quaternion _targetRotation;
    private Vector3 _targetPosition;

    public float MoveTime { get; set; }
    public GamePlayer CurrentPlayer { get; set; }

    public override IEnumerator Coroutine()
    {
        float currentTime = 0;
        GetTargetPositionAndRotation();

        while (currentTime < MoveTime)
        {
            UpdateRotation();
            UpdatePosition();

            currentTime += Time.deltaTime;
            yield return null;
        }
    }

    private void GetTargetPositionAndRotation()
    {
        Transform currentPoint = _points[CurrentPlayer.NetId - 2];
        _targetRotation = currentPoint.rotation;
        _targetPosition = currentPoint.position;
    }

    private void UpdatePosition()
    {
        Vector3 position = Vector3.Slerp(transform.position, _targetPosition, _rotateSmoothing * Time.deltaTime);
        transform.position = position;
    }

    private void UpdateRotation()
    {
        Quaternion rotation = Quaternion.Lerp(transform.rotation, _targetRotation, _rotateSmoothing * Time.deltaTime);
        transform.rotation = rotation;
    }
}