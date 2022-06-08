using UnityEngine;

public class Creature : DamageableObject
{
    private void Update()
    {
        GetComponentInChildren<MeshRenderer>().sortingOrder = -(int)(transform.position.y * 100);
    }

    public void InitializeCreature(WeaponType weaponType)
    {
        WeaponFactory.Instance.CreateObject(gameObject, TypeConvertor.ConvertEnumToType(weaponType));
    }
}
