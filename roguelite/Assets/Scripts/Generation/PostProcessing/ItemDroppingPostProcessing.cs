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
        _dropperTypes = itemDropperType.Assembly.ExportedTypes.Where(type => itemDropperType.IsAssignableFrom(type) && type != itemDropperType).ToList();

        foreach (var roomInstance in level.RoomInstances
                     .Select(room => room.RoomTemplateInstance)
                     .Where(room => room.GetComponent(typeof(ISpawner)) == null))
            AddRandomItemDropper(roomInstance);
    }

    private void AddRandomItemDropper(GameObject room)
    {
        room.AddComponent(_dropperTypes.GetRandomItemsInCollection(1).First());
    }
}