using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class WeaponDataInfo : Data
{
    [SerializeField] private WeaponType _weaponType;
    [SerializeField] private float _globalCooldownTime;
    [SerializeField] private GameObject _prefab;
    [SerializeField][Space] private List<AttackType> _weaponAttacks;

    public float GlobalCooldownTime => _globalCooldownTime;
    public GameObject Prefab => _prefab;
    public List<AttackType> WeaponAttacks => _weaponAttacks;

    public override Enum GetDataType()
    {
        return _weaponType;
    }
}
