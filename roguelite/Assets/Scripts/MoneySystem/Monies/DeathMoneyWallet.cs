using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/MoneyWallets/DeathCoin", fileName = "DeathMoneyWallet")]
public class DeathMoneyWallet : MoneyWallet
{
    public override ScriptableData Copy()
    {
        return this;
    }
}