public class EntityMoneyDropperRoom : MoneyDropperRoom
{
    protected override void Awake()
    {
        base.Awake();
        ItemName = "Entity money";
        _wallet = WalletsManager.Instance.FindWallet<EntityMoneyWallet>();
    }

    public override void DropItems()
    {
        _wallet.AddMoney(ItemsCount);
    }
}
