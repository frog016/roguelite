using UnityEngine;

public class AirEffect : Effect, IEffect
{
    private AttackData _parameters;
    private float _procProbability;
    private float _knockBackForce;
    private GameObject _player;

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _parameters = data.AttackParameters;
        _procProbability = data.ProcProbability;
        _knockBackForce = data.KnockBackForce;
        _player = data.Player;
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
        target.GetComponent<Rigidbody2D>().
            AddForce((_player.transform.position - target.transform.position) * _knockBackForce,
                ForceMode2D.Impulse);
    }
}
