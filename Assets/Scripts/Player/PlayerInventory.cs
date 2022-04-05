using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private WeaponData[] loadOut = new WeaponData[4];
    public WeaponData equippedWeapon {get; private set;}

    [SerializeField] private WeaponCollection weaponCollection;

    // Start is called before the first frame update
    void Start()
    {
        AddToLoadout(weaponCollection.weapons[0], 1); //HACK UNTIL SHOP
        AddToLoadout(weaponCollection.weapons[1], 2);
        AddToLoadout(weaponCollection.weapons[2], 3);
        equippedWeapon = loadOut[0];
    }

    public void AddToLoadout(WeaponData weapon , int invPosition)
    {
        loadOut[invPosition -1] = weapon;
    }

    public void EquipWeapon(int invSlot)
    {
        equippedWeapon = loadOut[invSlot - 1];
    }
}
