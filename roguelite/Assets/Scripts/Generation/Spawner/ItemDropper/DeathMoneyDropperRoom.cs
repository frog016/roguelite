public class DeathMoneyDropperRoom : MoneyDropperRoom
{
    protected override void Awake()
    {
        base.Awake();
        ItemName = " ������� �����";
        _wallet = WalletsManager.Instance.FindWallet<DeathMoneyWallet>();
    }

    public override void DropItems()
    {
        _wallet.AddMoney(ItemsCount);
    }
}
