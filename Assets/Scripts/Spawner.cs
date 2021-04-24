using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnLocations = default;
    [SerializeField] int numberOfSpawns = 200;

    private void Start()
    {
        for (int i = 0; i < numberOfSpawns; i++)
        {
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        GetComponent<PlaneGen>().SpawnMemory(spawnLocations[Random.Range(0, spawnLocations.Length)].position);
        yield return new WaitForSeconds(0.1f);
    }
}