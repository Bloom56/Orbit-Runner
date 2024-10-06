using System.Collections;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] debrisPrefabs;
    public int numberOfObjects = 10;
    public float spawnRadius = 10f;
    public float spawnInterval = 5f;  // Time between spawns

    void Start()
    {
        // Start the coroutine to spawn objects at intervals
        StartCoroutine(SpawnObjectsAtIntervals());
    }

    IEnumerator SpawnObjectsAtIntervals()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Select a random prefab and position
            GameObject randomPrefab = debrisPrefabs[Random.Range(0, debrisPrefabs.Length)];
            Vector3 randomPosition = transform.position + Random.insideUnitSphere * spawnRadius;

            // Spawn the object
            Instantiate(randomPrefab, randomPosition, Quaternion.identity);

            // Wait for the specified interval before spawning the next object
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
