using UnityEngine.Events;

public interface IWeapon
{
    void Attack();
    void AlternateAttack();
    public UnityEvent<AttackEventArgs> OnAttackEvent { get; set; }
}
