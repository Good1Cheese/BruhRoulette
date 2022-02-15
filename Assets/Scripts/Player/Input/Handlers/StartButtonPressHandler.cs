using UnityEngine;
using Zenject;

public class StartButtonPressHandler : MonoBehaviour
{
    [SerializeField] private LayerMask _startButtonMask;
    [SerializeField] private int _pressMaxDistance;

    private Ray _ray = new Ray();
    private GameStart _gameStart;

    [Inject]
    public void Construct(GameStart gameStart)
    {
        _gameStart = gameStart;
    }

    public void Handle(Transform playerTransform)
    {
        _ray.origin = playerTransform.position;
        _ray.direction = playerTransform.forward;

        if (!Physics.Raycast(_ray, out RaycastHit raycastHit, _pressMaxDistance, _startButtonMask)) { return; }

        if (_gameStart.GameStarted) { return; }

        raycastHit.collider.gameObject.SetActive(false);
        _gameStart.StartGame();
    }
}