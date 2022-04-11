using System;
using System.Collections.Generic;
using System.Linq;

public static class TypeConvertor
{
    private static Dictionary<Type, Enum> _types;

    static TypeConvertor()
    {
        _types = LoadTypes();
    }

    public static Enum ConvertTypeToEnum(Type type)
    {
        return _types[type];
    }

    private static Dictionary<Type, Enum> LoadTypes()
    {
        var types = new Dictionary<Type, Enum>();

        var typesParents = new List<Tuple<Type, Type>>
        {
            Tuple.Create(typeof(IWeapon), typeof(WeaponType)), 
            Tuple.Create(typeof(IEffect), typeof(EffectType))
        };

        foreach (var parent in typesParents)
            foreach (var type in parent.Item1.Assembly.ExportedTypes.Where(t => parent.Item1.IsAssignableFrom(t) && t != parent.Item1))
                types[type] = (Enum)Enum.Parse(parent.Item2, type.Name);

        return types;
    }
}
