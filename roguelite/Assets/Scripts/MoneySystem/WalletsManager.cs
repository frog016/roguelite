using System.Collections.Generic;
using System.Linq;
using ExtendedScriptableObject;
using UnityEngine;

[CreateAssetMenu(menuName = "Money/Wallets", fileName = "WalletsManager")]
public class WalletsManager : SingletonScriptableObject<WalletsManager>
{
    [SerializeField] private List<MoneyWallet> _wallets;

    public MoneyWallet FindWallet<T>() where T : MoneyWallet
    {
        return _wallets.FirstOrDefault(wallet => wallet.GetType() == typeof(T));
    }
}
