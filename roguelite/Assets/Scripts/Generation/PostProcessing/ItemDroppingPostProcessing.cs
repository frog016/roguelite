using System.Linq;
using Edgar.Unity;
using UnityEngine;

[CreateAssetMenu(menuName = "Edgar/Post processing/Item Droppers", fileName = "ItemDroppersPostProcessing")]
public class ItemDroppingPostProcessing : DungeonGeneratorPostProcessingGrid2D
{
    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
        foreach (var roomInstance in level.RoomInstances
                     .Select(room => room.RoomTemplateInstance)
                     .Where(room => room.GetComponent<PlayerSpawner>() == null))
            AddRandomItemDropper(roomInstance);
    }

    private void AddRandomItemDropper(GameObject room)
    {
        var itemDropperData = ItemDropperDataRepository.Instance.AllData;
        var chances = itemDropperData.Select(data => data.DroppingChance).ToList();
        var droppableTypes = itemDropperData.Select(data => data.GetAssociatedObjectType());
        var type = droppableTypes.GetRandomItemsWithChances(chances, 1).First();
        room.AddComponent(type);
    }
}