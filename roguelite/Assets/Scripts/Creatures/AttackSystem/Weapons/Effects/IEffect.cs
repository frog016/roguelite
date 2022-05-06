using System.Collections.Generic;

public interface IEffect
{
    void ApplyEffect(List<DamageableObject> targets);
}
