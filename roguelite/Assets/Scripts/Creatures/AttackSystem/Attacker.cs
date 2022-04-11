using System.Linq;
using UnityEngine;

[RequireComponent(typeof(EnemyFinder), typeof(Cooldown))]
public class Attacker : MonoBehaviour
{
    private IWeapon _currentWeapon;
    private EnemyFinder _enemyFinder;
    private Cooldown _attackCooldown;

    private void Awake()
    {
        _enemyFinder = GetComponent<EnemyFinder>();
        _attackCooldown = GetComponent<Cooldown>();
    }

    public void Initialize(IWeapon weapon)
    {
        _currentWeapon = weapon;
        _attackCooldown.CooldownTime = weapon.GetWeaponData().AttackParameters.AttackSpeed;
    }

    public void Attack() //TODO: Пока что общий кулдаун у атак
    {
        if (CanAttack())
            _currentWeapon.Attack(_enemyFinder.FindEnemy().FirstOrDefault());
    }

    public void AlternateAttack()
    {
        if (CanAttack())
            _currentWeapon.AlternateAttack(_enemyFinder.FindEnemy().FirstOrDefault());
    }

    private bool CanAttack()
    {
        return _attackCooldown.TryRestartCooldown() && _enemyFinder.HaveEnemy;
    }

}
