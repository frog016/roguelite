public abstract class MoneyDropperRoom<TItem, TData> : ItemDropperRoomBase
    where TItem: MoneyWallet
    where TData: MoneyDropperData
{
    public int CoinsCount { get; set; }

    private MoneyWallet _wallet;

    protected override void Awake()
    {
        base.Awake();
        _wallet = WalletsRepository.Instance.FindDataByType<TItem>();
    }

    public override void DropItems()
    {
        _wallet.AddMoney(CoinsCount);
    }

    protected override void FindItemData()
    {
        var moneyData = ItemDropperDataRepository.Instance.FindDataByType<TData>() as TData;
        ItemDropperData = moneyData;
        CoinsCount = moneyData.Range;
        moneyData.ResultDescription = moneyData.ResultDescription.Replace("{n}", $"{CoinsCount}");
    }
}
