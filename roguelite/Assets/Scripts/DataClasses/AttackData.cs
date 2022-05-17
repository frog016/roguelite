using System;
using UnityEngine;

[Serializable]
public class AttackData : Data
{
    [SerializeField] private AttackType _attackType;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _attackAngleDegrees;

    public float Damage => _damage;
    public float AttackSpeed => _attackSpeed; //TODO: Убрать это
    public float AttackRadius => _attackRadius;
    public float AttackAngleDegrees => _attackAngleDegrees;

    public Cooldown Cooldown { get; private set; }

    public void AddCooldown(Cooldown cooldown)
    {
        Cooldown = cooldown;
        Cooldown.CooldownTime = _attackSpeed;
    }

    public override Enum GetDataType()
    {
        return _attackType;
    }
}
