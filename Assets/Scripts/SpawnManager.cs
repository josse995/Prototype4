using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float startTime = 2;
    private float repeatTime = 2;
    private float spawnRange = 10;
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public int waveNumber = 1;

    [HideInInspector]
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating(nameof(SpawnBalls), startTime, repeatTime);
        //Instantiate(enemyPrefab, SpawnBall(), enemyPrefab.transform.rotation);
        Instantiate(powerupPrefab, GenerateRandomPosition(), powerupPrefab.transform.rotation);
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            ++waveNumber;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateRandomPosition(), powerupPrefab.transform.rotation);
            Debug.Log(string.Format("New wave number {0} spawned", waveNumber));
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; ++i)
        {
            Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);
        }
    }

    Vector3 GenerateRandomPosition()
    {
        var spawnPosX = Random.Range(-spawnRange, spawnRange);
        var spawnPosZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}
