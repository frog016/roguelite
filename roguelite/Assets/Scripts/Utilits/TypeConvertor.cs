using System;
using System.Collections.Generic;
using System.Linq;

public static class TypeConvertor
{
    private static Dictionary<Type, Enum> _types;
    private static Dictionary<Enum, Type> _enums;

    static TypeConvertor()
    {
        var tuple = LoadTypes();
        _types = tuple.Item1;
        _enums = tuple.Item2;
    }

    public static Enum ConvertTypeToEnum(Type type)
    {
        return _types[type];
    }

    public static Type ConvertEnumToType(Enum type)
    {
        return _enums[type];
    }

    private static (Dictionary<Type, Enum>, Dictionary<Enum, Type>) LoadTypes()
    {
        var types = new Dictionary<Type, Enum>();
        var enums = new Dictionary<Enum, Type>();

        var typesParents = new List<Tuple<Type, Type>>
        {
            Tuple.Create(typeof(WeaponBase), typeof(WeaponType)), 
            Tuple.Create(typeof(EffectBase), typeof(EffectType)),
            Tuple.Create(typeof(Creature), typeof(CreatureType)),
            Tuple.Create(typeof(AttackBase), typeof(AttackType)),
            Tuple.Create(typeof(Boss), typeof(CreatureType)),
            Tuple.Create(typeof(Item), typeof(ItemType))
        };

        foreach (var parent in typesParents)
            foreach (var type in parent.Item1.Assembly.ExportedTypes.Where(t => parent.Item1.IsAssignableFrom(t) && t != parent.Item1))
            {
                if (!Enum.IsDefined(parent.Item2, type.Name))
                    continue;

                var enumValue = (Enum)Enum.Parse(parent.Item2, type.Name);
                types[type] = enumValue;
                enums[enumValue] = type;
            }

        return (types, enums);
    }
}
