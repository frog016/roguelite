using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseHandler : MonoBehaviour
{
    private void Start()
    {
        GlobalEventManager.Instance.OnPlayerDeathEvent.AddListener(Lose);
    }

    private void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
