using System.Collections.Generic;
using UnityEngine;

public class MobsHpBarManager : MonoBehaviour
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
            Debug.Log("����" + creature.Key);
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
        hpBar.BarFront.transform.position = creature.transform.position + Vector3.up * 0.5f + Vector3.left * 0.35f;
        hpBar.BarBack.transform.position = creature.transform.position + Vector3.up * 0.5f + Vector3.left * 0.35f;
        hpBar.HpText.transform.position = creature.transform.position + Vector3.up * 0.5f + Vector3.left * 0.35f;
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
