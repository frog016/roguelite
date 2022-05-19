using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private int ScenNum;

    void OnTriggerEnter2D()
    {
        ChangeScene();
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(ScenNum);
    }
}
