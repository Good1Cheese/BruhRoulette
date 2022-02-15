using UnityEngine;

public class RevolverLoad : MonoBehaviour
{
    [SerializeField] private int _maxClipAmmo;
    [SerializeField] private int _minClipAmmo;

    private BulletCells _bulletCells;

    public BulletCells BulletCells => _bulletCells;

    private void Awake()
    {
        _bulletCells = new BulletCells(_maxClipAmmo);
        Load();
    }

    private void Load()
    {
        for (int i = 0; i < _maxClipAmmo; i++)
        {
            bool item = GetRandomBoolean();
            _bulletCells.Set(item, i);
        }
    }

    private bool GetRandomBoolean()
    {
        return Random.Range(0, 2) == 0;
    }
}