using System;
using UnityEngine;

public abstract class Creature : DamageableObject
{
    protected virtual void Update()
    {
        var meshRenderer = GetComponentInChildren<MeshRenderer>();
        meshRenderer.sortingOrder = -(int)(meshRenderer.transform.position.y * 100);
    }

    public void InitializeCreature(Type weaponType)
    {
        WeaponFactory.Instance.CreateObject(gameObject, weaponType);
    }
}
