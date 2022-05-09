using System.Collections.Generic;
using System.Linq;
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
        var effects = _weaponEffects.ToList();
        foreach (var effect in effects)
        {
            effect.ApplyEffect(targets);
            Debug.Log($"{effect} worked on {targets.Count} targets.");
        }
    }
}
