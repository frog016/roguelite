using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EffectDropperRoom : ItemDropperRoomBase
{
    public static EffectsAltar Altar;

    private Type _droppableItemType;
    private static List<Type> _allEffectsType;

    private void Awake()
    {
        _droppableItemType = typeof(EffectBase);
        _itemsCount = 4;

        _allEffectsType ??= _droppableItemType.Assembly.ExportedTypes.Where(type => _droppableItemType.IsAssignableFrom(type) && type != _droppableItemType).ToList();
        Altar ??= PrefabsFinder.FindObjectOfType<EffectsAltar>().GetComponent<EffectsAltar>();
    }

    public override void DropItems()
    {
        var grid = gameObject.GetComponentInChildren<Grid>();
        var position = grid.LocalToWorld(grid.GetComponentInChildren<Tilemap>().localBounds.center);
        position.z = -2f;   //  TODO: Убрать костыль
        var altar = Instantiate(Altar, position, Quaternion.identity);
        altar.SetEffects(_allEffectsType.GetRandomItemsInCollection(_itemsCount));
    }


}
