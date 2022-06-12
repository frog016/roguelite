using UnityEngine;

public abstract class ItemDropperData: ScriptableData
{
    [SerializeField] private float _droppingChance;
    [SerializeField] [TextArea] private string _resultDescription;

    public float DroppingChance => _droppingChance;

    public string ResultDescription { get => _resultDescription; set => _resultDescription = value; }
}
