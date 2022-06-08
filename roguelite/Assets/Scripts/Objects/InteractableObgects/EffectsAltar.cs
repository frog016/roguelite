using System;
using System.Collections.Generic;
using UnityEngine;

public class EffectsAltar : InteractableObject
{
    private List<Type> _types;

    public void SetEffects(List<Type> types) => _types = types;

    protected override void Start()
    {
        base.Start();
        EffectsSelectionPanel.Instance.OnEffectChosenEvent.AddListener(DestroyAltar);
    }

    public override void Interaction()
    {
        if (!Input.GetKeyDown(KeyCode.E))
            return;

        Debug.Log("Interact");
        EffectsSelectionPanel.Instance.ShowPanel(_types);
    }

    private void DestroyAltar()
    {
        HideText();
        Destroy(gameObject);
        EffectsSelectionPanel.Instance.OnEffectChosenEvent.RemoveListener(DestroyAltar);
    }
}
