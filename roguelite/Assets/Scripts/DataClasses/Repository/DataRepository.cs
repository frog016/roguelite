using System;
using System.Collections.Generic;
using System.Linq;
using ExtendedScriptableObject;
using UnityEngine;

public abstract class DataRepository<TRepository, TData> : SingletonScriptableObject<TRepository>, IJSONSerializable 
    where TRepository: SingletonScriptableObject<TRepository>
    where TData: ScriptableData
{
    [SerializeField] private ObservableList<TData> _data;

    public List<TData> AllData => _data.ToList();

    public TData FindDataByAssociatedType<T>()
    {
        return _data.FirstOrDefault(data => data.GetAssociatedObjectType() == typeof(T)).Copy() as TData;
    }

    public TData FindDataByAssociatedType(Type type)
    {
        return _data.FirstOrDefault(data => data.GetAssociatedObjectType() == type).Copy() as TData;
    }

    public TData FindDataByDataType<T>()
    {
        return _data.FirstOrDefault(data => data.GetType() == typeof(T)).Copy() as TData;
    }

    public TData FindDataByDataType(Type type)
    {
        return _data.FirstOrDefault(data => data.GetType() == type).Copy() as TData;
    }

    public void SaveDataToFile()
    {
        DBSerializationHelper.SaveObjectToJson(name, this);
    }

    public void LoadFromFile()
    {
        if (DBSerializationHelper.TryLoadJson(name, out var json))
            JsonUtility.FromJsonOverwrite(json, this);
    }

    private void OnEnable()
    {
        _data.Updated += SaveDataToFile;
    }
}
