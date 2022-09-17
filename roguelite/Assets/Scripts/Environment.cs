using UnityEngine;

public class Environment : MonoBehaviour
{
    private void Awake()
    {
        foreach (Transform transformObject in transform)
            transformObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = -(int)(transformObject.transform.position.y * 100);
    }
}
