using System;
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

    public void Handle(Transform camera)
    {
        if (!Raycast(camera) || _gameStart.IsStarted) { return; }

        _raycastHit.collider.gameObject.SetActive(false);
        _gameStart.StartGame();
    }

    private bool Raycast(Transform camera)
    {
        _ray.origin = camera.position;
        _ray.direction = camera.forward;

        return Physics.Raycast(_ray, out _raycastHit, _pressMaxDistance, _startButtonMask);
    }
}