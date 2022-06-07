using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    private void Start()
    {
        ShowLoadingScreen();
        LevelGenerationManager.Instance.OnGenerationEndedEvent.AddListener(CloseLoadingScreen);
    }

    private void ShowLoadingScreen()
    {
        gameObject.SetActive(true);
    }

    private void CloseLoadingScreen()
    {
        gameObject.SetActive(false);
    }
}
