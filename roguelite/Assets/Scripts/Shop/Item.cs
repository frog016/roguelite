using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected ItemData _data;

    public abstract void UseItem();
}
