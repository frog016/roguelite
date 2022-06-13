using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/MoneyWallets/Golden", fileName = "GoldenMoneyWallet")]
public class GoldenMoneyWallet : MoneyWallet
{
    public override ScriptableData Copy()
    {
        return this;
    }
}
