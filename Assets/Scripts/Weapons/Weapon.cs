using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Weapon : MonoBehaviour
{
    
    GameObject bulletPrefab;
    [SerializeField] WeaponData data;
    private float fireRate, bulletSpeed, burstAmount, lastShot;
    private bool isShotgun;
    private int SoundIndex;

    void Awake()
    {
        SetData();
    }

    // Start is called before the first frame update
    void Start()
    {
        lastShot = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        if (Time.time > lastShot + fireRate) 
        {
            if (isShotgun)
            {
                PelletShoot();
            }
            else
            {
                StartCoroutine(Burst()); 
            }
        }
    }

    //Instantiates based on for loop with a delay making the bullets comeout one by one
    private IEnumerator Burst()
    {
        for (int i = 0; i < burstAmount; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
                lastShot = Time.time;
                SoundManager.Instance.PlaySound(SoundIndex);
                yield return new WaitForSeconds(0.07f);
            }
    }

    //no delay so all the bullets will come out at the same time
    private void PelletShoot()
    {
        for (int i = 0; i < burstAmount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x + Random.Range(-1, 2), transform.position.y, transform.position.z + Random.Range(0, 4)), Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
            lastShot = Time.time;
            SoundManager.Instance.PlaySound(SoundIndex);
        }
    }


    //fills in the data int his script with the scriptable object data templates used to create different weapon types
    private void SetData()
    {
        bulletPrefab = data.bulletPrefab;
        fireRate = data.fireRate * 0.1f;
        bulletSpeed = data.bulletSpeed;
        burstAmount = data.burstAmount;
        isShotgun = data.isShotgun;
        SoundIndex = data.SoundIndex;
    }
    public void SetData(WeaponData data)
    {
        this.data = data;
        SetData();
    }

}
