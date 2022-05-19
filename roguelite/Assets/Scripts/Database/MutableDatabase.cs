using System;
using System.Linq;
using System.Reflection;
using ExtendedScriptableObject;
using UnityEngine;

namespace Database
{
    public class MutableDatabase<T> : SingletonScriptableObject<MutableDatabase<T>>, IJSONSerializable where T: Data
    {
        [SerializeField][InspectorName("Database")] private ObservableList<T> _list;

        private void OnEnable()
        {
            var a = typeof(T);
           LoadFromFile();
            _list.Updated += SaveDataToFile;
        }

        public T GetDataByType(Type type)
        {
            return _list.FirstOrDefault(e => e.GetDataType().Equals(TypeConvertor.ConvertTypeToEnum(type)));
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
    }
}