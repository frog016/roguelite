using System;
using System.Collections.Generic;
using System.Linq;

public class EffectDropperRoom : ItemDropperRoomBase
{
    private static List<Type> _allEffectsType;

    private void Awake()
    {
        _droppableItemType = typeof(EffectBase);
        _itemsCount = 3;

        _allEffectsType ??= _droppableItemType.Assembly.ExportedTypes.Where(_droppableItemType.IsAssignableFrom).ToList();
    }

    public override List<Type> DropItems()
    {
        return _allEffectsType.GetRandomItemsOfCollection(_itemsCount);
    }
}
