using System;
using UnityEngine;

[Serializable]
public class AttackDataInfo : AttackData
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private AttackType _attackType;

    public GameObject Prefab => _prefab;
    public AttackType AttackType => _attackType;

    public override Enum GetDataType()
    {
        return _attackType;
    }
}
