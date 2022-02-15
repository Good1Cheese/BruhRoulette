using System;

public class BulletCells
{
    private readonly bool[] _cells;
    private readonly bool[] _cellsBeforeScroll;

    public BulletCells(int cellsCount)
    {
        _cells = new bool[cellsCount];
        _cellsBeforeScroll = new bool[cellsCount];
    }

    public bool LastCell
    {
        get => _cells[_cells.Length - 1];
        set => _cells[_cells.Length - 1] = value;
    }

    public void Set(bool item, int index)
    {
        _cells[index] = item;
    }

    public bool GetLast()
    {
        bool last = LastCell;
        LastCell = false;
        Scroll();

        return last;
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