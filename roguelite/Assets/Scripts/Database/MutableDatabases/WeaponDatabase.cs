using UnityEngine;

namespace Database.MutableDatabases
{
    [CreateAssetMenu(menuName = "Databases/Weapons", fileName = "Weapons")]
    public class WeaponDatabase : MutableDatabase<WeaponData>
    {
    }
}
