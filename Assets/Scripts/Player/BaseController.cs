using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseController : MonoBehaviour
{
    private int Health = 1000;
    [SerializeField] private TMP_Text healthText;

    void Update()
    {
        healthText.text = "Health: " + Health;  //Keeps health UI updated
        if (Health <= 0)
        {
            GameManager.Instance.EndGameLoop(); //Pauses the game and sends to end screen
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            TakeDamage(35);
            Destroy(other.gameObject);
            SoundManager.Instance.PlaySound(4); //Explosion sound
        }
        else if (other.tag == "Boss")
        {
            TakeDamage(200);
            Destroy(other.gameObject);
            SoundManager.Instance.PlaySound(4); //Explosion sound
        }
    }
    

    private void TakeDamage(int dmg)
    {
        Health -= dmg;
        if (Health < 0)
        {
            Health = 0;
        }
    }
}
