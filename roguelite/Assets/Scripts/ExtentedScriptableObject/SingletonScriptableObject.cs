﻿using System;
using System.Linq;
using UnityEngine;

namespace ExtendedScriptableObject
{
    public class SingletonScriptableObject<T> : ScriptableObject where T: SingletonScriptableObject<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance is null)
                {
                    var assets = Resources.LoadAll<T>("");
                    if (assets is null || !assets.Any())
                    {
                        throw new Exception("Couldn't find any scriptable object instances in the Resources");
                    }
                    if (assets.Length > 1)
                    {
                        Debug.LogWarning("Multiple instances of the singleton found in the Resources");
                    }

                    _instance = assets.First();
                }

                return _instance;
            }
        }
    }
}