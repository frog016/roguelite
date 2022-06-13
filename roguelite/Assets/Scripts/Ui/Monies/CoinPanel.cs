using System;
using System.Linq;
using UnityEngine;

public class CoinPanel : MonoBehaviour
{
    private void Start()
    {
        var cards = GetComponentsInChildren<CoinItem>();
        foreach (var tuple in cards.Zip(WalletsRepository.Instance.AllData.ToList(), Tuple.Create))
        {
            ChangeItemText(tuple.Item1, tuple.Item2.Balance.ToString());
            tuple.Item2.OnBalanceUpdatedEvent.AddListener(() => ChangeItemText(tuple.Item1, tuple.Item2.Balance.ToString()));
        }
    }

    private void ChangeItemText(CoinItem item, string text)
    {
        item.UpdateText(text);
    }
}
