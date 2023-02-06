using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;
    public int spawnPosZ = -7;
    public int spawnPosX = 10;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, 5);
        InvokeRepeating("SpawnPowerup", 1, 20);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnEnemy()
    {
        var enemiesIndex = Random.Range(0, enemies.Length);
        var spawnX = Random.Range(-spawnPosX, spawnPosX);
        var spawnPos = new Vector3(spawnX, 1, spawnPosZ);
        Instantiate(enemies[enemiesIndex], spawnPos, enemies[enemiesIndex].gameObject.transform.rotation);

    }
    void SpawnPowerup()
    {
        var spawnX = Random.Range(-spawnPosX, spawnPosX);
        var powerupPos = new Vector3(spawnPosX, 1, spawnPosZ);
      
        Instantiate(powerup, powerupPos, powerup.gameObject.transform.rotation);

    }
}
