using UnityEngine;

namespace Database.MutableDatabases
{
    [CreateAssetMenu(menuName = "Databases/Creatures", fileName = "Creatures")]
    public class CreatureDatabase : MutableDatabase<CreatureData>
    {
    }
}