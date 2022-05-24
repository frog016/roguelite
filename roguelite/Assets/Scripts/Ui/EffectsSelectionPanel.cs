using System;
using System.Collections.Generic;
using System.Linq;
using Database.MutableDatabases;
using UnityEngine.UI;

public class EffectsSelectionPanel : SingletonObject<EffectsSelectionPanel>
{
    protected override void Awake()
    {
        base.Awake();
        gameObject.SetActive(false);
    }

    public void ShowPanel(List<Type> effectTypes)
    {
        var cards = GetComponentsInChildren<Button>().ToList();

        foreach (var pair in cards.Zip(effectTypes, Tuple.Create))
        {
            pair.Item1.onClick.RemoveAllListeners();
            pair.Item1.onClick.AddListener(() => CreateSelectedEffect(pair.Item2));
            pair.Item1.GetComponentInChildren<Text>().text = pair.Item2.Name;
        }

        PauseManager.Instance.Stop();
        gameObject.SetActive(true);
    }

    private void CreateSelectedEffect(Type effectType)
    {
        PlayerSpawner.Instance.Player.GetComponentInChildren<EffectsList>().AddOrUpdate(effectType);
        PauseManager.Instance.Continue();
        gameObject.SetActive(false);
    }

    private EffectData GetEffectData(Type type)
    {
        var data = EffectsDatabase.Instance.GetDataByType(type);
        return data;
    }
}
