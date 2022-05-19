using UnityEngine;

public abstract class AttackController : MonoBehaviour
{
    protected WeaponBase _weapon;

    protected virtual void Start()
    {
        _weapon = GetComponentInChildren<WeaponBase>();
    }

    public abstract void HandleInput(AttackType attackType = default);
}
