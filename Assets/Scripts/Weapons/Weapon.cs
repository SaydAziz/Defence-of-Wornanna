using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Weapon : MonoBehaviour
{
    
    GameObject bulletPrefab;
    [SerializeField] WeaponData data;
    private float lastShot;

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
        if (Time.time > lastShot + data.fireRate * 0.1f) 
        {
            if (data.isShotgun)
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
        for (int i = 0; i < data.burstAmount; i++)
            {
                GameObject bullet = Instantiate(data.bulletPrefab, transform.position, Quaternion.identity) as GameObject;
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * data.bulletSpeed, ForceMode.Impulse);
                lastShot = Time.time;
                SoundManager.Instance.PlaySound(data.SoundIndex);
                yield return new WaitForSeconds(0.07f);
            }
    }

    //no delay so all the bullets will come out at the same time
    private void PelletShoot()
    {
        for (int i = 0; i < data.burstAmount; i++)
        {
            GameObject bullet = Instantiate(data.bulletPrefab, new Vector3(transform.position.x + Random.Range(-1, 2), transform.position.y, transform.position.z + Random.Range(0, 4)), Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * data.bulletSpeed, ForceMode.Impulse);
            lastShot = Time.time;
            SoundManager.Instance.PlaySound(data.SoundIndex);
        }
    }

    public void SetData(WeaponData passedData)
    {
        this.data = passedData;
    }

}
