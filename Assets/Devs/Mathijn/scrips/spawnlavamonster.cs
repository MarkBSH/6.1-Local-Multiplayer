using UnityEngine;
using System.Collections;

public class SpawnPrefabsAroundPoint : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform midelPoint;
    public float spawnRadius = 5f;
    public float spawncooldown = 0.5f;
    public bool spawning = false;

    public void Start()
    {
        if (prefabToSpawn == null || midelPoint == null)
        {
            Debug.LogWarning("habiby you need to assighn the fucking prefab and middlepoint");
        } else 
        {
            StartCoroutine(SpawnPrefabsWithDelay());
        }
    }

    private IEnumerator SpawnPrefabsWithDelay()
    {
        while (spawning)
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPosition = midelPoint.position + new Vector3(randomDirection.x, 0, randomDirection.y) * spawnRadius;
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawncooldown);
        }
    }
}
