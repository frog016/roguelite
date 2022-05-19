using UnityEngine;

public class PlayerAttackController : AttackController
{
    private void Update()
    {
        if (!Input.anyKeyDown)
            return;

        HandleInput();
    }

    public override void HandleInput(AttackType attackType = default)
    {
        if (Mathf.Abs(Input.GetAxis("Fire1")) > 1e-12)
            _weapon.TryAttack((_weapon as Weapon)?.AttackTypes[0]);
        if (Mathf.Abs(Input.GetAxis("Fire2")) > 1e-12)
            _weapon.TryAttack((_weapon as Weapon)?.AttackTypes[1]);
    }
}
