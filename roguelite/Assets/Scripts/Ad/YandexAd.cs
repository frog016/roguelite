using System;
using Agava.YandexGames;
using UnityEngine;

public class YandexAd : MonoBehaviour
{
    [SerializeField] private int _deathCount;

    private void Start()
    {
        GlobalEventManager.Instance.OnPlayerDeathEvent.AddListener(CheckDeath);
        _deathCount = PlayerStatistic.Instance.DeathCount;
    }

    private void CheckDeath()
    {
        _deathCount++;
        if (_deathCount % 2 == 0)
            PlayAd();
    }

    private void PlayAd()
    {
        #if UNITY_WEBGL
        try
        {
            VideoAd.Show();
        }
        catch (Exception e)
        {
            Debug.Log("¬ы не в яндекс играх");
        }
        #endif
        Debug.Log("Ad");
    }
}
