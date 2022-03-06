using UnityEngine;
using Zenject;

public class RevolverLoad : MonoBehaviour
{
    private const int CellsCount = 6;

    private RevolverCells _revolverCells;
    private GameStart _gameStart;

    public RevolverCells RevolverCells => _revolverCells;

    [Inject]
    public void Construct(GameStart gameStart)
    {
        _gameStart = gameStart;
    }

    private void Start()
    {
        _gameStart.Started += Load;
    }

    private void Load()
    {
        _revolverCells = new RevolverCells(CellsCount);

        int random = GetRandomCell();
        _revolverCells.Fill(random);
    }

    private int GetRandomCell()
    {
        return Random.Range(0, 5);
    }

    private void OnDestroy()
    {
        _gameStart.Started -= Load;
    }
}