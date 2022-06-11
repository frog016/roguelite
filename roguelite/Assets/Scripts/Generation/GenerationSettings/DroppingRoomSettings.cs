using System;
using System.Collections.Generic;
using System.Linq;
using ExtendedScriptableObject;
using UnityEngine;

[CreateAssetMenu(menuName = "Generation/Settings/DroppingRoomSettings", fileName = "DroppingRoomSettings")]
public class DroppingRoomSettings : SingletonScriptableObject<DroppingRoomSettings>
{
    [Header("Effects")] 
    [SerializeField] private float _chance1;
    private Type _type1 = typeof(EffectDropperRoom);

    [Header("Golden monies")]
    [SerializeField] private float _chance2;
    private Type _type2 = typeof(GoldenMoneyDropperRoom);

    [Header("Entities")]
    [SerializeField] private float _chance3;
    private Type _type3 = typeof(EntityMoneyDropperRoom);

    [Header("Effects")]
    [SerializeField] private float _chance4;
    private Type _type4 = typeof(DeathMoneyDropperRoom);

    public List<Tuple<float, Type>> Settings()
    {
        var chances = new List<float>
        {
            _chance1,
            _chance2,
            _chance3,
            _chance4
        };

        var dropperTypes = new List<Tuple<float, Type>>
        {
            Tuple.Create(_chance1, _type1),
            Tuple.Create(_chance2, _type2),
            Tuple.Create(_chance3, _type3),
            Tuple.Create(_chance4, _type4)
        };

        return dropperTypes.OrderBy(pair => pair.Item1).ToList();
    }
}