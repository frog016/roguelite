using Agava.YandexGames;
using UnityEngine;

public class YandexAd : MonoBehaviour
{
    [SerializeField] private int _deathCount;

    private void Start()
    {
        GlobalEventManager.Instance.OnPlayerDeathEvent.AddListener(CheckDeath);
    }

    private void CheckDeath()
    {
        _deathCount++;
        if (_deathCount % 2 == 0)
            PlayAd();
    }

    private void PlayAd()
    {
        VideoAd.Show();
}
}
