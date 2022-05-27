using UnityEngine;

public class PauseManager : SingletonObject<PauseManager>
{
    public void Continue() => Time.timeScale = 1f;

    public void Stop() => Time.timeScale = 0f;

    public void Exit() => Application.Quit();
}
