using UnityEngine;

public abstract class MoneyDropperData : ItemDropperData
{
    [SerializeField] private Vector2Int _range;

    public int Range => Random.Range(_range.x, _range.y + 1);
}
