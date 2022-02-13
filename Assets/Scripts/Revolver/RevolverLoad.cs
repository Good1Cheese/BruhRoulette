using System;
using System.Collections.Generic;
using UnityEngine;

public class RevolverLoad : MonoBehaviour
{
    [SerializeField] private float _maxClipAmmo;
    [SerializeField] private float _minClipAmmo;

    private Stack<bool> _bulletCells = new Stack<bool>();

    public Stack<bool> BulletCells => _bulletCells;

    private void Awake()
    {
        Load();
    }

    private void Load()
    {
        for (int i = 0; i < _maxClipAmmo; i++)
        {
            _bulletCells.Push(GetRandomTrueFalse());
        }
    }

    public void LoadWithClean()
    {
        _bulletCells.Clear();
        Load();
    }

    private bool GetRandomTrueFalse() => UnityEngine.Random.Range(0, 1) == 0;
}