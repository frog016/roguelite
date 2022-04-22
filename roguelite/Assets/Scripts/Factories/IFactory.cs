using System;
using UnityEngine;

public interface IFactory<T>
{
    void CreateObject(GameObject parent, Type objectType);
}
