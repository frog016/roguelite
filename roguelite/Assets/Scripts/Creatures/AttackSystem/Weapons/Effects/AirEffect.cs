using UnityEngine;

public class AirEffect : MonoBehaviour, IEffect //доделать эволв
{
    private AttackParameters _parameters;
    private float _procProbability;
    private float _knockBackForce;
    //private PolygonCollider2D _area;
    private bool _isEvolved;
    private GameObject _player;

    public AirEffect(EffectData data)
    {
        _parameters = data.AttackParameters;
        _procProbability = data.ProcProbability;
        _knockBackForce = data.KnockBackForce;
        _isEvolved = data.IsEvolved;
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
            AddForce((_player.transform.position - target.GetComponent<Transform>().position) * _knockBackForce, 
            ForceMode2D.Impulse);
    }
}
