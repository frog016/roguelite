public class AttackList : ComponentList<AttackBase>
{
    public void LoadAttacks()
    {
        foreach (var attackBase in GetComponentsInChildren<AttackBase>())
        {
            _elements.Add(attackBase);
            attackBase.Initialize(AttackDataRepository.Instance.FindDataByAssociatedType(attackBase.GetType()));
            OnListUpdated.Invoke(attackBase);
        }
    }
}
