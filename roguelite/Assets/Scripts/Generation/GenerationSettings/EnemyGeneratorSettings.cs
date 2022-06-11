using System;
using System.Linq;
using ExtendedScriptableObject;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Generation/Settings/Enemies", fileName = "EnemyGeneratorSettings")]
public class EnemyGeneratorSettings : SingletonScriptableObject<EnemyGeneratorSettings>
{
    [SerializeField] private Range _uniqueUnitsRange;
    [SerializeField] private Range _unitRange;

    public SpawnData GenerateRandomUnits()
    {
        var creatureTypes = Enum.GetNames(typeof(CreatureType))
            .Select(creature => (CreatureType)Enum.Parse(typeof(CreatureType), creature)).ToList();
        creatureTypes.Remove(CreatureType.HeroSamurai);
        creatureTypes.Remove(CreatureType.Gasadokuro);
        creatureTypes.Remove(CreatureType.HugeSkeleton);

        var enemyTypes = creatureTypes.GetRandomItems(Random.Range(_uniqueUnitsRange.Min, _uniqueUnitsRange.Max + 1));
        var data = enemyTypes
            .Select(type => new SpawnUnitsData(type, Random.Range(_unitRange.Min, _unitRange.Max + 1)));

        return new SpawnData(data.ToList());
    }
}
