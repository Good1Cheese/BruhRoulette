using System;

public class RevolverCells
{
    private readonly bool[] _cells;
    private readonly bool[] _cellsBeforeScroll;

    private int _cellIndex = -1;

    public RevolverCells(int cellsCount)
    {
        _cells = new bool[cellsCount];
        _cellsBeforeScroll = new bool[cellsCount];
    }

    public void Set(bool item)
    {
        _cells[++_cellIndex] = item;
    }

    public bool GetLast()
    {
        bool currentCell = _cells[_cellIndex];
        _cells[_cellIndex--] = false;

        Scroll();

        return currentCell;
    }

    public void Scroll()
    {
        Array.Copy(_cells, _cellsBeforeScroll, _cells.Length);

        _cells[0] = _cellsBeforeScroll[_cells.Length - 1];

        for (int i = 1; i < _cells.Length; i++)
        {
            _cells[i] = _cellsBeforeScroll[i - 1];
        }
    }
}