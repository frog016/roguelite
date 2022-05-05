using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeStealEffect : MonoBehaviour, IEffect //доделать прибавку хп персонажу и эволв(стил урона)
{
    private AttackParameters _parameters;
    private float _lifestealAmount;
    private GameObject _player;

    public LifeStealEffect(EffectData data)
    {
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
        //_player.GetComponent<DamageableObject>()._health += _lifestealAmount; требуется доступ к увеличению хп в классе DamageableObject
    }

    private void StealPowerDamage(DamageableObject target)
    {
        
    }


}
