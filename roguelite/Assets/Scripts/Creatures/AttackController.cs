using UnityEngine;

public abstract class AttackController : MonoBehaviour
{
    protected IWeapon _weapon;

    protected virtual void Start()
    {
        _weapon = GetComponentInChildren<Weapon>() as IWeapon;
    }

    public abstract void HandleInput(AttackType attackType = default);
}
