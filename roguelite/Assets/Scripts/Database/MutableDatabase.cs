using System;
using System.Linq;
using ExtendedScriptableObject;
using UnityEngine;

namespace Database
{
    public class MutableDatabase<T> : SingletonScriptableObject<MutableDatabase<T>>, IJSONSerializable where T: Data
    {
        [SerializeField] private ObservableList<T> _list;

        private void OnEnable()
        {
           LoadFromFile();
            _list.Updated += SaveDataToFile;
        }

        public T GetDataByType(Type type)
        {
            return _list.FirstOrDefault(e => e.DataType.Equals(TypeConvertor.ConvertTypeToEnum(type)));
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