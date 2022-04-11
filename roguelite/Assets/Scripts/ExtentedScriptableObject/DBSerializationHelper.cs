using System.IO;
using UnityEngine;

namespace ExtendedScriptableObject
{
    public static class DBSerializationHelper
    {
        private static string _scriptableObjectsDataDirectory = "DatabaseSaves";

        public static void SaveObjectToJson(string name, object obj)
        {
            string dirPath = System.IO.Path.Combine(Application.persistentDataPath, _scriptableObjectsDataDirectory);
            string filePath = System.IO.Path.Combine(dirPath, $"{name}.json");
            
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);
            
            if (!File.Exists(filePath))
                File.Create(filePath).Dispose();

            string json = JsonUtility.ToJson(obj);
            File.WriteAllText(filePath, json);
        }
        
        public static bool TryLoadJson(string name, out string data)
        {
            string filePath = System.IO.Path.Combine(Application.persistentDataPath, _scriptableObjectsDataDirectory,
                $"{name}.json"
            );

            data = null;
            
            if (!File.Exists(filePath))
                return false;

            data = File.ReadAllText(filePath);
            return true;
        }
    }
}