using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Relation
{
    [SerializeField] private CreatureType _creature;
    [SerializeField] private List<CreatureType> _enemies;

    public CreatureType Creature => _creature;
    public List<CreatureType> Enemies => _enemies;
}
