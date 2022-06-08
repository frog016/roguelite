using System;
using System.Collections.Generic;
using UnityEngine;

public class EffectsAltar : InteractableObject
{
    public List<Type> EffectTypes { get; set; }

    public override void Interaction()
    {
        if (!Input.GetKeyDown(KeyCode.E))
            return;

        EffectsSelectionPanel.Instance.OpenPanel(this);
    }

    public void CreateEffect(Type effectType)
    {
        PlayerSpawner.Instance.Player.GetComponentInChildren<EffectList>().AddOrUpdate(effectType);
        DestroyAltar();
    }

    private void DestroyAltar()
    {
        HideText();
        Destroy(gameObject);
    }
}
