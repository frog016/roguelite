using System.Collections.Generic;

public interface IAttack
{
    List<DamageableObject> Attack();
    bool IsReady();
}
