using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : SingletonObject<EnemyDetector>
{
    [SerializeField] private List<Relation> _relations;

    private Dictionary<Type, HashSet<Type>> _allRelations;

    protected override void Awake()
    {
        base.Awake();
        BuildRelations();
    }

    public bool IsEnemy(Type selfType, Type enemyType)
    {
        return _allRelations[selfType].Contains(enemyType);
    }

    private void BuildRelations()
    {
        _allRelations = new Dictionary<Type, HashSet<Type>>();
        foreach (var relation in _relations)
        {
            foreach (var enemy in relation.Enemies)
            {
                var creatureType = TypeConvertor.ConvertEnumToType(relation.Creature);
                var enemyType = TypeConvertor.ConvertEnumToType(enemy);
                AddInDictionary(creatureType, enemyType);
                AddInDictionary(enemyType, creatureType);
            }
        }
    }

    private void AddInDictionary(Type key, Type value)
    {
        if (!_allRelations.ContainsKey(key))
        {
            _allRelations.Add(key, new HashSet<Type> {value});
            return;
        }

        _allRelations[key].Add(value);
    }
}
