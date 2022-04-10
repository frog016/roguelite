public class AttackParameters
{
    public float Damage { get; set; }
    public float AttackSpeed { get; set; }

    public AttackParameters(float damage, float attackSpeed)
    {
        Damage = damage;
        AttackSpeed = attackSpeed;
    }
}
