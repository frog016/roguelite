using System.Collections.Generic;
using UnityEngine;

public class MobsHpBarManager : SingletonObject<MobsHpBarManager>
{
    [SerializeField] private Canvas Canv;
    [SerializeField] private GameObject HpBarPrefab;
    [SerializeField] private Dictionary<MobHpBar, Creature> Bars;

    private void Start()
    {
        Bars = new Dictionary<MobHpBar, Creature>();
    }

    public void AddCreature(Creature creature)
    {
        var hpBar = Instantiate(HpBarPrefab, Canv.transform);
        Bars.Add(hpBar.GetComponent<MobHpBar>(), creature);
    }

    void Update()
    {
        if (Bars.Count > 0)
            UpdateBars();
    }

    private void UpdateBars()
    {
        var creaturesToDelete = new List<MobHpBar>();
        foreach (var creature in Bars)
        {
            //Debug.Log("ключ" + creature.Key);
            if (creature.Value == null)
            {
                creaturesToDelete.Add(creature.Key);
                continue;
            }
            creature.Key.BarFront.fillAmount = creature.Value.Health / creature.Value.MaxHealth;
            creature.Key.HpText.text = creature.Value.Health.ToString();

            Follow(creature.Value, creature.Key);
        }

        DeleteBars(creaturesToDelete);
    }

    private void Follow(Creature creature, MobHpBar hpBar)
    {
        hpBar.transform.position = creature.transform.position + Vector3.up * 0.25f;
    }

    private void DeleteBars(List<MobHpBar> bars)
    {
        foreach (var bar in bars)
        {
            Bars.Remove(bar);
            Destroy(bar.gameObject);
        }
    }
}
