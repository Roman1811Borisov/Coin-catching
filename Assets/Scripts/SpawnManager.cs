using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float minSpawnPositionX = -18;
    private float maxSpawnPositionX = 18;
    private float SpawnPositionY = 1;
    private float SpawnPositionZ = 180;
    [SerializeField] private float startDelay = 2;
    [SerializeField] private float repeatRate = 1;
    [SerializeField] private GameObject[] obstaclesPrefabs;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    void Update()
    {

    }

    void SpawnObstacle()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minSpawnPositionX, maxSpawnPositionX), SpawnPositionY, SpawnPositionZ);

        int randomObstacleNumber = Random.Range(0, obstaclesPrefabs.Length);
        Instantiate(obstaclesPrefabs[randomObstacleNumber], CreateRandomSpawnPosition(), obstaclesPrefabs[randomObstacleNumber].transform.rotation); //ABSTRACTION  
    }

    Vector3 CreateRandomSpawnPosition() // ABSTRACTION
    {
        return new Vector3(Random.Range(minSpawnPositionX, maxSpawnPositionX), SpawnPositionY, SpawnPositionZ);
    }
}