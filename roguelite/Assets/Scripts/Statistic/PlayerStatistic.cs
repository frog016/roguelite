using ExtendedScriptableObject;
using UnityEngine;

[CreateAssetMenu(menuName = "Statistic/Player", fileName = "PlayerStatistic")]
public class PlayerStatistic : SingletonScriptableObject<PlayerStatistic>, IJSONSerializable
{
    [SerializeField] private int _deathCount;

    public int DeathCount
    {
        get => _deathCount;
        set
        {
            _deathCount = value;
            SaveDataToFile();
        }
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
