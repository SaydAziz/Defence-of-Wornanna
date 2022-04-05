using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCollection", menuName = "Data/Weapon Collection")]

public class WeaponCollection : ScriptableObject
{
    [SerializeField] private WeaponData[] _weapons = new WeaponData[8];

    public WeaponData[] weapons
    {
        get { return _weapons;}
    }
    
}
