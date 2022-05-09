using System;
using UnityEngine;

public interface IFactory<T>
{
    T CreateObject(GameObject parent, Type objectType);
}
