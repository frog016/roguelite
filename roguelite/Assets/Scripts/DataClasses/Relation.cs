using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Relation
{
    [SerializeField] private GameObject _creature;
    [SerializeField] private List<GameObject> _enemies;

    public Type Creature => _creature.GetComponent<Creature>().GetType();
    public List<Type> Enemies => _enemies.Select(enemy => enemy.GetComponent<Creature>().GetType()).ToList();
}
