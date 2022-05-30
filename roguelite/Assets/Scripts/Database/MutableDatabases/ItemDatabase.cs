using UnityEngine;

namespace Database.MutableDatabases
{
    [CreateAssetMenu(menuName = "Databases/Items", fileName = "ItemDatabase")]
    public class ItemDatabase : MutableDatabase<ItemDataInfo>
    {
    }
}