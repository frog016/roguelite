using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/MoneyWallets/Entity", fileName = "EntityMoneyWallet")]
public class EntityMoneyWallet : MoneyWallet
{
    public override ScriptableData Copy()
    {
        return this;
    }
}