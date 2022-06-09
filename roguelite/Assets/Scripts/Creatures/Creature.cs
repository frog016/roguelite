using UnityEngine;

public class Creature : DamageableObject
{
    private void Update()
    {
        var meshRenderer = GetComponentInChildren<MeshRenderer>();
        meshRenderer.sortingOrder = -(int)(meshRenderer.transform.position.y * 100);
    }

    public void InitializeCreature(WeaponType weaponType)
    {
        WeaponFactory.Instance.CreateObject(gameObject, TypeConvertor.ConvertEnumToType(weaponType));
    }
}
