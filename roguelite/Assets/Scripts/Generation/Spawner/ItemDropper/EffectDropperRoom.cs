using System;
using System.Linq;
using UnityEngine;

public class EffectDropperRoom : ItemDropperRoomBase
{
    private Type _droppableItem;
    private EffectsAltar _altar;

    public override void DropItems()
    {
        var altar = Instantiate(_altar, PlayerSpawner.Instance.Player.transform.position, Quaternion.identity);
        altar.EffectTypes = _droppableItem.Assembly.ExportedTypes.Where(type => _droppableItem.IsAssignableFrom(type) && !type.IsAbstract).ToList(); ;
    }

    protected override void FindItemData()
    {
        var effectData = ItemDropperDataRepository.Instance.FindDataByType<EffectDropperData>() as EffectDropperData;
        ItemDropperData = effectData;
        _droppableItem = effectData.GetDataType();
        _altar = effectData.AltarPrefab.GetComponent<EffectsAltar>();
    }
}
