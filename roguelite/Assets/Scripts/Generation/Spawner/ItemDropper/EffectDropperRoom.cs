using System.Linq;
using UnityEngine;

public class EffectDropperRoom : ItemDropperRoomBase
{
    private EffectsAltar _altar;

    public override void DropItems()
    {
        var altar = Instantiate(_altar, PlayerSpawner.Instance.Player.transform.position, Quaternion.identity);
        var droppableItem = typeof(EffectBase);
        altar.EffectTypes = droppableItem.Assembly.ExportedTypes.Where(type => droppableItem.IsAssignableFrom(type) && !type.IsAbstract).ToList(); ;
    }

    public override void Initialize()
    {
        var effectData = ItemDropperDataRepository.Instance.FindDataByAssociatedType(GetType()) as EffectDropperData;
        ItemDropperData = effectData;
        _altar = effectData.AltarPrefab.GetComponent<EffectsAltar>();
    }
}
