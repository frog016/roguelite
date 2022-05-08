using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public IWeapon CurrentWeapon { get; private set; }
    public WeaponData Data { get; private set; }

    private List<IEffect> _weaponEffects;

    private void Start()
    {
        _weaponEffects = GetComponentInChildren<EffectsList>().Effects;
    }

    public void SetWeapon(IWeapon weapon, WeaponData data)
    {
        CurrentWeapon = weapon;
        Data = data;
        CurrentWeapon.OnAttack.AddListener(ActivateEffects);
    }

    private void ActivateEffects(List<DamageableObject> targets)
    {
        foreach (var effect in _weaponEffects)
            effect.ApplyEffect(targets);
    }
}
