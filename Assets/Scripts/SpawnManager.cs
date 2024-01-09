using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float minSpawnPositionX = -18;
    private float maxSpawnPositionX = 18;
    private float SpawnPositionY = 2;
    private float SpawnPositionZ = 180;
    [SerializeField] private float startObstacleDelay = 2;
    [SerializeField] private float startCoinDelay = 3;
    [SerializeField] private float repeatRate = 1;
    [SerializeField] private GameObject[] obstaclesPrefabs;
    [SerializeField] private GameObject[] coinPrefabs;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startObstacleDelay, repeatRate);
        InvokeRepeating("SpawnCoin", startCoinDelay, repeatRate);
    }

    void SpawnObstacle()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minSpawnPositionX, maxSpawnPositionX), SpawnPositionY, SpawnPositionZ);

        int randomObstacleNumber = Random.Range(0, obstaclesPrefabs.Length);
        Instantiate(obstaclesPrefabs[randomObstacleNumber], CreateRandomSpawnPosition(), obstaclesPrefabs[randomObstacleNumber].transform.rotation); //ABSTRACTION  
    }

    void SpawnCoin()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minSpawnPositionX, maxSpawnPositionX), SpawnPositionY, SpawnPositionZ);

        int randomObstacleNumber = Random.Range(0, coinPrefabs.Length);
        Instantiate(coinPrefabs[randomObstacleNumber], CreateRandomSpawnPosition(), coinPrefabs[randomObstacleNumber].transform.rotation); //ABSTRACTION  
    }

    Vector3 CreateRandomSpawnPosition() // ABSTRACTION
    {
        return new Vector3(Random.Range(minSpawnPositionX, maxSpawnPositionX), SpawnPositionY, SpawnPositionZ);
    }
}