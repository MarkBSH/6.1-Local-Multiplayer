using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class coinsspawn : MonoBehaviour
{
    private bool spawning = true; 
    public Transform midelPoint;
    public GameObject prefabToSpawn;
    public float spawncooldown = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startspawing()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator startspawing()
    {
        while (spawning)
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPosition = midelPoint.position + new Vector3(randomDirection.x, 0, randomDirection.y) * Random.Range(1f, 12f);
            Vector3 directionToMiddle = (midelPoint.position - spawnPosition).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(directionToMiddle);
            Quaternion finalRotation = lookRotation * Quaternion.Euler(0, 90, 0);

            GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, finalRotation);

            yield return new WaitForSeconds(spawncooldown);
        }
    }
}
