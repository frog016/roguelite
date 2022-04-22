using UnityEngine;

[RequireComponent(typeof(TargetsFinder))]
public abstract class Attacker : MonoBehaviour
{
    protected TargetsFinder _targetsFinder;

    private void Awake()
    {
        _targetsFinder = GetComponent<TargetsFinder>();
    }

    public abstract void Attack();

    public abstract void AlternateAttack();

    protected bool CanAttack()
    {
        return true;
    }
}
