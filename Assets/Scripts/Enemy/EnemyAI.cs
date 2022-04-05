using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private int health = 100;
    [SerializeField] private ParticleSystem Boom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, 0, -0.1f)); //constant movement towards base
        if (health <= 0)
        {
            Die();
        }
    }


    public void TakeDamage(int dmg)
    {
        health -= dmg;
    }

    private void Die()
    {

        Destroy(this.gameObject);
        Instantiate(Boom, this.transform.position, this.transform.rotation);
        SoundManager.Instance.PlaySound(3);
        GameManager.Instance.AddScore(100);
    }
}
