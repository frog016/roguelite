public class GoldenMoneyDropperRoom : MoneyDropperRoom
{
    protected override void Awake()
    {
        base.Awake();
        ItemName = "Golden money";
        _wallet = WalletsManager.Instance.FindWallet<GoldenMoneyWallet>();
    }

    public override void DropItems()
    {
        _wallet.AddMoney(ItemsCount);
    }
}
