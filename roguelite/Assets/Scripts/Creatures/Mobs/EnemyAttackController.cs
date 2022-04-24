using UnityEngine;

public class EnemyAttackController : MonoBehaviour
{
    private IWeapon _weapon;

    private void Start()
    {
        _weapon = GetComponentInChildren<Weapon>().CurrentWeapon;
        GetComponent<EnemyMoveController>().OnTargetReached.AddListener(() => _weapon.Attack());
    }
}
