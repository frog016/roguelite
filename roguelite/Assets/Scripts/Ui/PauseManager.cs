using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : SingletonObject<PauseManager>
{
    public void Continue() => Time.timeScale = 1f;

    public void Stop() => Time.timeScale = 0f;

    public void ReturnToMenu() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    public void Exit() 
    {
        Application.Quit();
        Continue();
    }
}
