using System.Collections.Generic;
using UnityEngine.Events;

public interface IWeapon
{
    void Attack();
    void AlternateAttack();
    public UnityEvent<List<DamageableObject>> OnAttack { get; set; }
}
