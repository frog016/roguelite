using UnityEngine;

public class LifeStealEffect : Effect, IEffect
{
    private AttackData _parameters;
    private float _lifestealAmount;
    private GameObject _player;

    public override void InitializeEffect(EffectData data)
    {
        base.InitializeEffect(data);
        _parameters = data.AttackParameters;
        _lifestealAmount = data.LifestealAmount;
        _player = data.Player;
    }

    public void ApplyEffect(DamageableObject target)
    {
        IncreaseHealthPoints();
        StealPowerDamage(target);
    }

    private void IncreaseHealthPoints()
    {
        //_player.GetComponent<DamageableObject>()._health += _lifestealAmount;
    }

    private void StealPowerDamage(DamageableObject target)
    {

    }
}
