using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/WeaponData/WeaponData", fileName = "WeaponData")]
public class WeaponData : ScriptableData
{
    [SerializeField] private float _globalCooldownTime;
    [SerializeField] private GameObject _prefab;

    public float GlobalCooldownTime => _globalCooldownTime;
    public GameObject Prefab => _prefab;

    protected virtual void Initialize(float globalCooldown, GameObject prefab)
    {
        _globalCooldownTime = globalCooldown;
        _prefab = prefab;
    }

    public override Type GetAssociatedObjectType()
    {
        return _prefab.GetComponent<WeaponBase>().GetType();
    }

    public override ScriptableData Copy()
    {
        var copy = CreateInstance<WeaponData>();
        copy.Initialize(_globalCooldownTime, _prefab);
        return copy;
    }
}
