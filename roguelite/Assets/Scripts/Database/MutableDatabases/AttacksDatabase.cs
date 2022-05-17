using UnityEngine;

namespace Database.MutableDatabases
{
    [CreateAssetMenu(menuName = "Databases/Attacks", fileName = "Attacks")]
    public class AttacksDatabase : MutableDatabase<AttackData>
    {
    }
}