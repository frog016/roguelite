using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Creature : DamageableObject
{
    private Attacker _attacker;

    private void Awake()
    {
        _attacker = GetComponentInChildren<Attacker>();
    }

    private void Start()
    {
        _attacker.Initialize(WeaponFactory.Instance.CreateObject(typeof(DualKatanas)));
    }

}
