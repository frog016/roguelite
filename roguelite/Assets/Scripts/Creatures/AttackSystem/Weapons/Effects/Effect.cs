using UnityEngine;

public class Effect : MonoBehaviour
{
    protected AttackData _parameters;
    protected float _procProbability;
    protected float _duration;

    public virtual void InitializeEffect(EffectData data)
    {
        _parameters = data.AttackParameters;
        _procProbability = data.ProcProbability > 1e-10 ? data.ProcProbability : 1;
        _duration = data.Duration;
    }
}
