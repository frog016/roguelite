using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    void Start()
    {
        foreach (Transform obj in transform)
        {
            obj.GetComponent<SpriteRenderer>().sortingOrder = -(int)(obj.transform.position.y * 100);
        }
    }
}
