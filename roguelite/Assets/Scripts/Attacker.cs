using System.Linq;
using UnityEngine;

[RequireComponent(typeof(EnemyFinder))]
public class Attacker : MonoBehaviour
{
    private IWeapon _currentWeapon;
    private EnemyFinder _enemyFinder;

    private void Awake()
    {
        _enemyFinder = GetComponent<EnemyFinder>();
    }

    public void Initialize(IWeapon weapon)
    {
        _currentWeapon = weapon;
    }

    public void Attack()
    {
        _currentWeapon.Attack(_enemyFinder.FindEnemy().First());
    }

    public void AlternateAttack()
    {
        _currentWeapon.AlternateAttack(_enemyFinder.FindEnemy().First());
    }
}
