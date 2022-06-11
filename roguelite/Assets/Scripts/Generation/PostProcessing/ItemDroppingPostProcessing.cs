using System;
using System.Collections.Generic;
using System.Linq;
using Edgar.Unity;
using UnityEngine;

[CreateAssetMenu(menuName = "Edgar/Post processing/Item Droppers", fileName = "ItemDroppersPostProcessing")]
public class ItemDroppingPostProcessing : DungeonGeneratorPostProcessingGrid2D
{
    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
        var itemDropperType = typeof(ItemDropperRoomBase);
        //_dropperTypes = itemDropperType.Assembly.ExportedTypes.Where(type => itemDropperType.IsAssignableFrom(type) && !type.IsAbstract).OrderBy(type => type.Name).ToList();

        foreach (var roomInstance in level.RoomInstances
                     .Select(room => room.RoomTemplateInstance)
                     .Where(room => room.GetComponent<PlayerSpawner>() == null))
            AddRandomItemDropper(roomInstance);
    }

    private void AddRandomItemDropper(GameObject room)
    {
        var settings = DroppingRoomSettings.Instance.Settings();
        var chances = settings.Select(pair => pair.Item1).ToList();
        var dropperTypes = settings.Select(pair => pair.Item2).ToList();

        room.AddComponent(dropperTypes.GetRandomItemsWithChances(chances, 1).First());
        //room.AddComponent(typeof(EffectDropperRoom));
    }
}