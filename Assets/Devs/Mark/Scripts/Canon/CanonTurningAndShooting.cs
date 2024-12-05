using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTurningAndShooting : MonoBehaviour
{
    [SerializeField] float baseTurnSpeed; // Base rotation speed
    float turnSpeed; // Current rotation speed

    [SerializeField] GameObject bulletPrefab; // Prefab for the bullet
    [SerializeField] Transform bulletSpawnPoint; // Point where the bullet will be instantiated

    void Start()
    {
        turnSpeed = baseTurnSpeed;
    }

    void Update()
    {


        // Rotate the cannon
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
    }

    // Coroutine to handle shooting
    public IEnumerator Shoot()
    {

        turnSpeed = 0;
        yield return new WaitForSeconds(0.5f);

        Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));

        yield return new WaitForSeconds(0.5f);
        turnSpeed = baseTurnSpeed;

    }
}
