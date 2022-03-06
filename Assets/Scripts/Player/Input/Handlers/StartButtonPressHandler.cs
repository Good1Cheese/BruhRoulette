using UnityEngine;
using Zenject;

public class StartButtonPressHandler : MonoBehaviour
{
    [SerializeField] private LayerMask _startButtonMask;
    [SerializeField] private int _pressMaxDistance;

    private RaycastHit _raycastHit;
    private Ray _ray = new Ray();
    private GameStart _gameStart;

    [Inject]
    public void Construct(GameStart gameStart)
    {
        _gameStart = gameStart;
    }

    public void Handle(Transform playerTransform)
    {
        if (!Raycast(playerTransform) || _gameStart.IsStarted) { return; }

        _raycastHit.collider.gameObject.SetActive(false);
        _gameStart.StartGame();
    }

    private bool Raycast(Transform playerTransform)
    {
        _ray.origin = playerTransform.position;
        _ray.direction = playerTransform.forward;

        return Physics.Raycast(_ray, out _raycastHit, _pressMaxDistance, _startButtonMask);
    }
}