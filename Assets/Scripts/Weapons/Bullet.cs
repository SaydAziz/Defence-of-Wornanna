using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int Damage = 20;

    void Start()
    {
        StartCoroutine(DeathTimer());
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyAI>().TakeDamage(Damage);
            Destroy(this.gameObject);
        }
        else if (other.tag == "Boss")
        {
            other.gameObject.GetComponent<BossAi>().TakeDamage(Damage);
            Destroy(this.gameObject);
        }
    }

    private IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
