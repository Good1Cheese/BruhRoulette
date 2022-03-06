using System;

public class RevolverCells
{
    private readonly bool[] _cells;
    private readonly bool[] _cellsBeforeScroll;

    public bool[] Cells => _cells;

    public RevolverCells(int cellsCount)
    {
        _cells = new bool[cellsCount];
        _cellsBeforeScroll = new bool[cellsCount];
    }

    public void Fill(int index) => Cells[index] = true;

    public bool GetLast()
    {
        bool currentCell = Cells[0];
        Cells[0] = false;

        Scroll();

        return currentCell;
    }

    public void Scroll()
    {
        Array.Copy(Cells, _cellsBeforeScroll, Cells.Length);

        Cells[0] = _cellsBeforeScroll[Cells.Length - 1];

        for (int i = 1; i < Cells.Length; i++)
        {
            Cells[i] = _cellsBeforeScroll[i - 1];
        }
    }
}