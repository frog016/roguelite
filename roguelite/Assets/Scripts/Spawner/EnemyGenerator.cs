using System;
using System.Linq;
using ExtendedScriptableObject;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Enemies/Generation", fileName = "EnemyGenerator")]
public class EnemyGenerator : SingletonScriptableObject<EnemyGenerator>
{
    [SerializeField] private Range _uniqueUnitsRange;
    [SerializeField] private Range _unitRange;

    public SpawnData GenerateRandomUnits()
    {
        var data = new SpawnData();
        var creatureTypes = Enum.GetNames(typeof(CreatureType))
            .Select(creature => (CreatureType)Enum.Parse(typeof(CreatureType), creature)).ToList();
        creatureTypes.Remove(CreatureType.HeroSamurai);
        creatureTypes.Remove(CreatureType.Gasadokuro);

        var count = Random.Range(_uniqueUnitsRange.Min, _uniqueUnitsRange.Max + 1);
        for (var i = 0; i < count; i++)
        {
            var unitsData = new SpawnUnitsData(
                creatureTypes[Random.Range(0, creatureTypes.Count)],
                Random.Range(_uniqueUnitsRange.Min, _uniqueUnitsRange.Max + 1));
            data.Units.Add(unitsData);
        }

        return data;
    }
}
