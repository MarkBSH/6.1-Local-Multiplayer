using UnityEngine;
using System.Collections;

public class SpawnLavaMonster : MonoBehaviour
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
            Instantiate(prefabToSpawn, spawnPosition, lookRotation);
            yield return new WaitForSeconds(spawncooldown);
        }
    }

    public void stopspawn()
    {
        spawning = false;
    }

    public void startspawn()
    {
        spawning = true;
        StartCoroutine(startspawing());
    }
}
