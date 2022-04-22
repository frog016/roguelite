using UnityEngine;

public class Weapon : MonoBehaviour
{
    public IWeapon CurrentWeapon { get; private set; }

    public void SetWeapon(IWeapon weapon)
    {
        CurrentWeapon = weapon;
    }
}
