using UnityEngine;

public abstract class EffectBase : MonoBehaviour
{
    public EffectData EffectData { get; protected set; }

    public virtual void Initialize(EffectData data)
    {
        EffectData = data;
    }

    public abstract void ApplyEffect(AttackEventArgs attackEventArgs);

    protected virtual void PlayVisualEffect(Transform start = null, Transform target = null)
    {
        start ??= transform;
        target ??= transform;

        var particle = Instantiate(EffectData.Info.VisualEffect, start).GetComponent<ParticleSystem>();
        particle.transform.rotation =
                Quaternion.LookRotation(
                    (target.position - start.position));

        var mainModule = particle.main;
        mainModule.duration = EffectData.Duration;

        particle.Play();
    }
}
