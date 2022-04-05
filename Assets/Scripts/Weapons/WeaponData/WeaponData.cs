using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Data/Weapon Data")]
public class WeaponData : ScriptableObject
{
    
    [SerializeField] private  GameObject _bulletPrefab;
    public GameObject bulletPrefab 
    {
        get { return _bulletPrefab; }
    }

    [SerializeField] private  float _fireRate;
    public float fireRate 
    {
        get { return _fireRate; }
    } 

    [SerializeField] private  float _bulletSpeed;
    public float bulletSpeed 
    {
        get { return _bulletSpeed; }
    } 

    [SerializeField] private  float _burstAmount;
    public float burstAmount 
    {
        get { return _burstAmount; }
    } 

    [SerializeField] private  bool _isShotgun;
    public bool isShotgun 
    {
        get { return _isShotgun; }
    } 

    [SerializeField] private  int _soundIndex;
    public int SoundIndex 
    {
        get { return _soundIndex; }
    } 

    

}
