using UnityEngine;

public class SingletonObject<T> : MonoBehaviour where T: SingletonObject<T>
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (!Instance)
            Instance = gameObject.GetComponent<T>();
        else if (Instance == this)
            Destroy(gameObject);
    }
}
