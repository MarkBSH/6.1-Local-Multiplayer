using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnLavaMonster : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform midelPoint;
    public float spawnRadius = 5f;
    public float spawncooldown = 0.5f;
    public bool spawning = false;

    private List<GameObject> spawnedObjects = new List<GameObject>(); 

    public void Start()
    {
        if (prefabToSpawn == null || midelPoint == null)
        {
            Debug.LogWarning("Habiby, you need to assign the prefab and the middle point!");
        }
        else
        {
            StartCoroutine(startspawing());
        }
    }

    private IEnumerator startspawing()
    {
        while (spawning)
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPosition = midelPoint.position + new Vector3(randomDirection.x, 0, randomDirection.y) * spawnRadius;
            Vector3 directionToMiddle = (midelPoint.position - spawnPosition).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(directionToMiddle);
            Quaternion finalRotation = lookRotation * Quaternion.Euler(0, 90, 0);

            GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, finalRotation); 
            spawnedObjects.Add(spawnedObject); 

            yield return new WaitForSeconds(spawncooldown);
        }
    }

    public void stopspawn()
    {
        spawning = false;
        DestroyAllSpawnedObjects();
    }

    public void startspawn()
    {
        spawning = true;
        StartCoroutine(startspawing());

    }

    public void DestroyAllSpawnedObjects()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            if (obj != null)
            {
                Destroy(obj); 
            }
        }
        spawnedObjects.Clear();
    }
}
