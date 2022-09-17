using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int SceneNum;
    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneNum);
    }
}
