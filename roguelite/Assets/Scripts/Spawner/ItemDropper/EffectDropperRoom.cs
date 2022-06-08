using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EffectDropperRoom : ItemDropperRoomBase
{
    private EffectsAltar _altar;
    private Type _droppableItemType;
    private List<Type> _allEffectsType;

    private void Awake()
    {
        _droppableItemType = typeof(EffectBase);
        ItemsCount = 4;

        _altar = PrefabsFinder.FindObjectOfType<EffectsAltar>().GetComponent<EffectsAltar>();
        _allEffectsType = _droppableItemType.Assembly.ExportedTypes.Where(type => _droppableItemType.IsAssignableFrom(type) && !type.IsAbstract).ToList();
    }

    public override void DropItems()
    {
        var grid = gameObject.GetComponentInChildren<Grid>();
        var position = grid.LocalToWorld(grid.GetComponentInChildren<Tilemap>().localBounds.center);
        var altar = Instantiate(_altar, position, Quaternion.identity);
        altar.SetEffects(_allEffectsType.GetRandomItems(ItemsCount));
    }


}
