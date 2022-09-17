using System.Collections;
using System.Collections.Generic;

public class SummonAcolytes : AttackBase
{
    protected override IEnumerator AttackCoroutine()
    {
        yield return base.AttackCoroutine();

        _cooldown.TryRestartCooldown();
        //RoomManager.Instance.CurrentRoom.RoomTemplateInstance.GetComponent<ISpawner>().SpawnUnits(CreateAcolytesData());

        OnAttackCompletedEvent.Invoke(new AttackEventArgs(this, new List<DamageableObject>()));
    }
}
