using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public abstract class ComponentList<T> : MonoBehaviour, IEnumerable<T> where T: MonoBehaviour
{
    public UnityEvent<T> OnListUpdated { get; private set; }

    protected List<T> _elements;

    protected virtual void Awake()
    {
        OnListUpdated = new UnityEvent<T>();
        _elements = new List<T>();
    }

    protected T Add(Type elementType)
    {
        var element = gameObject.AddComponent(elementType) as T;
        _elements.Add(element);

        return element;
    }

    public void Replace(Type oldElement, Type newElement)
    {
        var element = _elements.FirstOrDefault(effect => effect.GetType() == oldElement);
        if (element == null)
            return;

        _elements.Remove(element);
        Add(newElement);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _elements.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public T this[int index] => _elements[index];
}
