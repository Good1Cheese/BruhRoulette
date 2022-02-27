using UnityEngine;
using Zenject;

public class RevolverLoad : MonoBehaviour
{
    private RevolverCells _revolverCells;
    private PlayersList _playersList;
    private GameStart _gameStart;

    public RevolverCells RevolverCells => _revolverCells;

    [Inject]
    public void Construct(PlayersList playersList, GameStart gameStart)
    {
        _playersList = playersList;
        _gameStart = gameStart;
    }

    private void Start()
    {
        _gameStart.Started += Load;
    }

    private void Load()
    {
        _revolverCells = new RevolverCells(_playersList.List.Count);

        for (int i = 0; i < _playersList.List.Count; i++)
        {
            bool item = GetRandomBoolean();
            _revolverCells.Set(item);
        }
    }

    private bool GetRandomBoolean()
    {
        return Random.Range(0, 2) == 0;
    }

    private void OnDestroy()
    {
        _gameStart.Started -= Load;
    }
}