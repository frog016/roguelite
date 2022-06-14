using UnityEngine;

public abstract class Creature : DamageableObject
{
    protected virtual void Update()
    {
        var meshRenderer = GetComponentInChildren<MeshRenderer>();
        meshRenderer.sortingOrder = -(int)(meshRenderer.transform.position.y * 100);
    }

    public void InitializeCreature(CreatureData data)
    {
        Health = data.MaxHealth;
        MaxHealth = data.MaxHealth;

        WeaponFactory.Instance.CreateObject(gameObject, data.WeaponType);
        GetComponent<MoveController>().MovementData = data.MovementData;
    }
}
