using System;
using System.Collections.Generic;
using UnityEngine;

public class EffectsAltar : MonoBehaviour
{
    public List<Type> Types { get; private set; }

    public void SetEffects(List<Type> types) => Types = types;

    private void OnMouseDown()
    {
        if (!EffectsSelectionPanel.Instance.gameObject.activeInHierarchy)
            EffectsSelectionPanel.Instance.ShowPanel(this);
    }
}
