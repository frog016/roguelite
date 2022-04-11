using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private Attacker _attacker;

    private void Awake()
    {
        _attacker = GetComponentInChildren<Attacker>();
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
            _attacker.Attack();
        if (Mathf.Abs(Input.GetAxis("Fire2")) > 1e-12)
            _attacker.AlternateAttack();
    }
}
