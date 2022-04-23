using UnityEngine;

public class AirEffect : MonoBehaviour, IEffect //доделать эволв и отталкивание
{
    private AttackParameters _parameters;
    private float _procProbability;
    private float _knockBackForce;
    //private PolygonCollider2D _area;
    private bool isEvolved;

    public AirEffect(EffectData data)
    {
        _parameters = data.AttackParameters;
        _procProbability = data.ProcProbability;
        _knockBackForce = data.KnockBackForce;
    }

    public void ApplyEffect(DamageableObject target)
    {
        if (!RandomChanceGenerator.IsEventHappen(_procProbability))
            return;

        ApplyDamage(target);
        KnockBack(target);
    }

    private void ApplyDamage(DamageableObject target)
    {
        target.ApplyDamage(_parameters.Damage);
    }

    private void KnockBack(DamageableObject target)
    {
        
    }
}
