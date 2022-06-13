using UnityEngine;

public abstract class ItemDropperData: ScriptableData
{
    [SerializeField] protected float _droppingChance;
    [SerializeField] [TextArea] protected string _resultDescription;

    public float DroppingChance => _droppingChance;

    public string ResultDescription { get => _resultDescription; set => _resultDescription = value; }

    protected virtual void Initialize(float droppingChance, string resultDescription)
    {
        _droppingChance = droppingChance;
        _resultDescription = string.Copy(resultDescription);
    }
}
