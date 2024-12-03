using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Destroy the game object after 0.2 seconds
        Destroy(gameObject, 0.2f);
    }

    // This function is called when the collider other enters the collision
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy the game object immediately upon collision
            Destroy(gameObject);
        }

    }
}
