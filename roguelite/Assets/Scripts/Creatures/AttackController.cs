using UnityEngine;

public abstract class AttackController : MonoBehaviour
{
    public WeaponBase Weapon;

    protected virtual void Start()
    {
        Weapon = GetComponentInChildren<WeaponBase>();
    }

    public abstract void HandleInput(AttackType attackType = default);
}
