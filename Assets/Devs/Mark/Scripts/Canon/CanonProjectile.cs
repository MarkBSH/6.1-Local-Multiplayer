using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonProjectile : MonoBehaviour
{
    public float speed = 20f; // The speed at which the projectile moves forward
    public GameObject explosionEffect; // Reference to the explosion effect prefab
    public GameObject explosionHit; // Reference to the explosion hit prefab
    [SerializeField] GameObject explosionAudio;

    void Start()
    {
        // Set the projectile's velocity to move forward
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        // Create the explosion effect at the projectile's position
        Instantiate(explosionEffect, transform.position, transform.rotation);
        // Create the explosion hit at the projectile's position
        Instantiate(explosionHit, transform.position, transform.rotation);
        Instantiate(explosionAudio, transform.position, transform.rotation);
        // Destroy the projectile after collision
        Destroy(gameObject);
    }
}
