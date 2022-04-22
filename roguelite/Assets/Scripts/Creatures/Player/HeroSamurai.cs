public class HeroSamurai : Creature
{
    private void Start()
    {
        WeaponFactory.Instance.CreateObject(gameObject, typeof(DualKatanas));
    }
}
