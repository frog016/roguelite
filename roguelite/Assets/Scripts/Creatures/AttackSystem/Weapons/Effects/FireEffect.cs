using System.Collections;
using UnityEngine;

public class FireEffect : MonoBehaviour, IEffect
{
    private bool _isEvolved;
    private AttackParameters _parameters;
    private float _procProbability;
    private float _duration;

    public FireEffect(EffectData data)
    {
        _parameters = data.AttackParameters;
        _procProbability = data.ProcProbability;
        _duration = data.Duration;
        _isEvolved = data.IsEvolved;
    }

    public void ApplyEffect(DamageableObject target)
    {
        if (!RandomChanceGenerator.IsEventHappen(_procProbability))
            return;

        StartCoroutine(ApplyDamageOverTime(target));
    }

    private IEnumerator ApplyDamageOverTime(DamageableObject target)
    {
        var counter = 0;
        while (counter < _duration)
        {
            if(_isEvolved) target.ApplyDamage(target.Health / 100 * 25 / _duration); //ÒÐÅÁÓÅÒÑß ÌÀÊÑ ÕÏ Ó ÊËÀÑÑÀ DamageableObject
            else target.ApplyDamage(_parameters.Damage);
            yield return new WaitForSeconds(_parameters.AttackSpeed);
            counter++;
        }
    }
}
