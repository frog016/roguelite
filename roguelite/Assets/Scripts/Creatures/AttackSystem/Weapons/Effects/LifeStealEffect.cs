using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeStealEffect : MonoBehaviour, IEffect //�������� �������� �� ��������� � �����(���� �����)
{
    private AttackParameters _parameters;
    private float _lifestealAmount;

    public LifeStealEffect(EffectData data)
    {
        _parameters = data.AttackParameters;
        _lifestealAmount = data.LifestealAmount;
    }

    public void ApplyEffect(DamageableObject target)
    {


        
    }

    private void IncreaseHealthPoints()
    {

    }

    private void StealPowerDamage()
    {

    }


}
