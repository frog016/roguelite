using System;
using System.Collections.Generic;
using UnityEngine;

public class EffectsAltar : MonoBehaviour
{
    private List<Type> _types;

    public void SetEffects(List<Type> types) => _types = types;

    private void OnMouseDown()
    {
        if (!EffectsSelectionPanel.Instance.gameObject.activeInHierarchy)
            EffectsSelectionPanel.Instance.ShowPanel(_types);
    }
}
