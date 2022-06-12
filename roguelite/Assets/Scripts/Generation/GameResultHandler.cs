using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResultHandler : MonoBehaviour
{
    [SerializeField] private GameObject _winWindow;
    [SerializeField] private GameObject _loseWindow;

    private void Start()
    { 
        GlobalEventManager.Instance.OnBossDeathEvent.AddListener(() => LoadResultWindow(_winWindow, Win));
        GlobalEventManager.Instance.OnPlayerDeathEvent.AddListener(() => LoadResultWindow(_loseWindow, Lose));
    }

    private void Win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void Lose()
    {
        WalletsRepository.Instance.AllData.ForEach(wallet => wallet.TrySpendMoney(wallet.Balance));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadResultWindow(GameObject window, Action resultAction)
    {
        window.SetActive(true);
        StartCoroutine(WaitForKeyDownCoroutine(resultAction));
    }

    private IEnumerator WaitForKeyDownCoroutine(Action resultAction)
    {
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => Input.anyKeyDown);
        resultAction.Invoke();
    }
}
