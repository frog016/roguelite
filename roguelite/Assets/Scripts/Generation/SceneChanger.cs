using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class SceneChanger : MonoBehaviour
{
    private void ChangeSceneOnNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<HeroSamurai>() == null)
            return;

        ChangeSceneOnNext();
    }
}
