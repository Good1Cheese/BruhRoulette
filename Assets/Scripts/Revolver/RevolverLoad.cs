using UnityEngine;
using Zenject;

public class RevolverLoad : MonoBehaviour
{
    private const int CellsCount = 6;

    private RevolverCells _revolverCells;
    private GameStart _gameStart;
    private FireButtonInputHandler _fireButtonInputHandler;

    private int RandomCell => Random.Range(0, 5);
    public RevolverCells RevolverCells => _revolverCells;

    [Inject]
    public void Construct(GameStart gameStart, FireButtonInputHandler fireButtonInputHandler)
    {
        _gameStart = gameStart;
        _fireButtonInputHandler = fireButtonInputHandler;
    }

    private void Start()
    {
        _gameStart.Started += Load;
        _fireButtonInputHandler.Handled += Load;

        _revolverCells = new RevolverCells(CellsCount);
    }

    private void Load()
    {
        int random = RandomCell;
        _revolverCells.Fill(random);
    }


    private void OnDestroy()
    {
        _gameStart.Started -= Load;
    }
}