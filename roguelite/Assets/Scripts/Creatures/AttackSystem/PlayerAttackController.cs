using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private IWeapon _weapon;

    private void Start()
    {
        _weapon = GetComponentInChildren<Weapon>() as IWeapon;
    }

    private void Update()
    {
        if (!Input.anyKeyDown)
            return;

        HandleKeyboardInput();
    }

    private void HandleKeyboardInput()
    {
        if (Mathf.Abs(Input.GetAxis("Fire1")) > 1e-12)
            _weapon.Attack((_weapon as Weapon)?.AttackTypes[0]);
        if (Mathf.Abs(Input.GetAxis("Fire2")) > 1e-12)
            _weapon.Attack((_weapon as Weapon)?.AttackTypes[1]);
    }
}
