using UnityEngine;

public abstract class MoneyDropperData : ItemDropperData
{
    [SerializeField] protected Vector2Int _range;

    public int Range => Random.Range(_range.x, _range.y + 1);

    protected void Initialize(float droppingChance, string resultDescription, Vector2Int range)
    {
        base.Initialize(droppingChance, resultDescription);
        _range = range;
    }
}
