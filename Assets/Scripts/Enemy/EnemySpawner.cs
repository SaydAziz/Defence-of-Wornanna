using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject[] enemyPrefab;
    private float spawnRate = 3;
    private int enemyLvl = 0;
    private float nextSpawn = 0;
    private int spawnLvl = 1;

    private bool firstBoss = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("IncreaseSpawnrate"); //Timer to increase difficulty
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }


    private void SpawnEnemy()
    {
        if (Time.time > nextSpawn) //checks if there has been enough delay to spawn next enemy
        {
            nextSpawn = Time.time + spawnRate;
            Instantiate(enemyPrefab[enemyLvl], new Vector3(transform.position.x + Random.Range(-15, 16), transform.position.y, transform.position.z  + Random.Range(-3, 4)), Quaternion.identity);
            
        }
    }


    private IEnumerator IncreaseSpawnrate()
    {
        yield return new WaitForSeconds(30);

        spawnLvl++;
        spawnRate /= 1.3f;

        if (spawnLvl % 4 == 0 && spawnLvl < 13)
        {
            enemyLvl++;

            if (enemyLvl == 3 && firstBoss)
            {
                spawnRate = 8;
                firstBoss = false;
            }
        }
        


        if (spawnLvl % 5 == 0)
        {
            Instantiate(spawner, transform.position, transform.rotation);
            spawnRate = 3;
        }
        StartCoroutine("IncreaseSpawnrate");
    }

}
