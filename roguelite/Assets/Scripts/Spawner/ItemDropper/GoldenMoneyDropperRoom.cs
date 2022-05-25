public class GoldenMoneyDropperRoom : MoneyDropperRoom
{
    protected override void Awake()
    {
        base.Awake();
        _wallet = WalletsManager.Instance.FindWallet<GoldenMoneyWallet>();
    }

    public override void DropItems()
    {
        _wallet.AddMoney(_itemsCount);
    }
}
