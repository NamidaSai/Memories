using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnLocations = default;
    [SerializeField] int numberOfSpawns = 200;
    [SerializeField] float spawnRadius = 2f;

    [SerializeField] int memoryProbability = 50;
    [SerializeField] int circleProbability = 10;
    [SerializeField] int wallProbability = 30;
    [SerializeField] int hazardProbabilty = 10;

    [SerializeField] GameObject wallPrefab = default;
    [SerializeField] GameObject circlePrefab = default;
    [SerializeField] GameObject hazardPrefab = default;

    Vector3 nextSpawnLocation;

    private void Start()
    {
        for (int i = 0; i < numberOfSpawns; i++)
        {
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        int randomChance = Random.Range(0, memoryProbability + wallProbability + circleProbability + hazardProbabilty);
        if (randomChance < memoryProbability)
        {
            GetComponent<PlaneGen>().SpawnMemory(PickTargetPosition());
        }
        else if (randomChance < memoryProbability + wallProbability)
        {
            SpawnWall();
        }
        else if (randomChance < memoryProbability + wallProbability + circleProbability)
        {
            SpawnCircle();
        }
        else
        {
            SpawnHazard();
        }

        yield return new WaitForSeconds(0.1f);
    }
    private Vector3 RandomPointOnUnitCircle(float radius)
    {
        float angle = Random.Range(0f, Mathf.PI * 2);
        float x = Mathf.Sin(angle) * radius;
        float y = Mathf.Cos(angle) * radius;

        return new Vector3(x, y, 0);
    }

    private Vector3 PickTargetPosition()
    {
        nextSpawnLocation = spawnLocations[Random.Range(0, spawnLocations.Length)].position + RandomPointOnUnitCircle(spawnRadius);
        return nextSpawnLocation;
    }

    private void SpawnWall()
    {
        Instantiate(wallPrefab, PickTargetPosition(), Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
    }

    private void SpawnCircle()
    {
        Instantiate(circlePrefab, PickTargetPosition(), Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
    }

    private void SpawnHazard()
    {
        Instantiate(hazardPrefab, PickTargetPosition(), Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
    }
}