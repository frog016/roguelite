public class AttackList : ComponentList<AttackBase>
{
    protected override void Awake()
    {
        base.Awake();
        foreach (var attackBase in GetComponentsInChildren<AttackBase>())
        {
            _elements.Add(attackBase);
            attackBase.Initialize(AttackDataRepository.Instance.FindDataByAssociatedType(attackBase.GetType()));
            OnListUpdated.Invoke(attackBase);
        }
    }
}
