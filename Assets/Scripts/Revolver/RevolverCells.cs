using System;
using UnityEngine;

public class RevolverCells
{
    private readonly bool[] _cells;
    private readonly bool[] _cellsBeforeScroll;

    private int _cellIndex = -1;

    public bool[] Cells => _cells;

    public RevolverCells(int cellsCount)
    {
        _cells = new bool[cellsCount];
        _cellsBeforeScroll = new bool[cellsCount];
        _cellIndex = cellsCount - 1;
    }

    public void SetGay(int index)
    {
        Cells[index] = true;

        for (int i = 0; i < _cells.Length; i++)
        {
            Debug.Log(_cells[i]);
        }
    }

    public bool GetLast()
    {
        bool currentCell = Cells[_cellIndex];
        Cells[_cellIndex--] = false;

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