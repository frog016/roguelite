using System;
using System.Collections.Generic;
using System.Linq;
using Edgar.Unity;
using UnityEngine;

[CreateAssetMenu(menuName = "Edgar/Post processing/Item Droppers", fileName = "ItemDroppersPostProcessing")]
public class ItemDroppingPostProcessing : DungeonGeneratorPostProcessingGrid2D
{
    private List<Type> _dropperTypes;

    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
        var itemDropperType = typeof(ItemDropperRoomBase);
        _dropperTypes = itemDropperType.Assembly.ExportedTypes.Where(itemDropperType.IsAssignableFrom).ToList();

        foreach (var roomInstance in level.RoomInstances
                     .Select(room => room.RoomTemplateInstance)
                     .Where(room => room.GetComponent<ISpawner>() == null))
            AddRandomItemDropper(roomInstance);
    }

    private void AddRandomItemDropper(GameObject room)
    {
        room.AddComponent(_dropperTypes.GetRandomItemsOfCollection(1).First());
    }
}