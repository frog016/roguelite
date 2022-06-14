using System;
using System.Collections.Generic;
using System.Linq;
using ExtendedScriptableObject;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Generation/Settings/Enemies", fileName = "EnemyGeneratorSettings")]
public class EnemyGeneratorSettings : SingletonScriptableObject<EnemyGeneratorSettings>
{
    [SerializeField] private Range _uniqueUnitsRange;
    [SerializeField] private Range _unitRange;

    private List<Type> _creatureTypes;

    public SpawnData GenerateRandomUnits()
    {
        _creatureTypes ??= FindAllCreatures();
        _creatureTypes.Remove(typeof(Gasadokuro));
        _creatureTypes.Remove(typeof(HeroSamurai));
        _creatureTypes.Remove(typeof(HugeSkeleton));

        var enemyTypes = _creatureTypes.GetRandomItems(Random.Range(_uniqueUnitsRange.Min, _uniqueUnitsRange.Max + 1));
        var data = enemyTypes
            .Select(type => new SpawnUnitsData(type, Random.Range(_unitRange.Min, _unitRange.Max + 1)));

        return new SpawnData(data.ToList());
    }

    private List<Type> FindAllCreatures()
    {
        var type = typeof(Creature);
        return type.Assembly.ExportedTypes
            .Where(creature => type.IsAssignableFrom(creature) && !creature.IsAbstract)
            .ToList();
    }
}
