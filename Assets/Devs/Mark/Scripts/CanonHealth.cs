using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonHealth : MonoBehaviour
{
    public float health = 3; // Initial health of the cannon
    public GameObject img1; // Reference to the first health image
    public GameObject img2; // Reference to the second health image
    public GameObject img3; // Reference to the third health image

    void Start()
    {
        UpdateHealthImages(); // Initialize the health UI
    }

    void Update()
    {
        // No update logic needed
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("CanonHit"))
        {
            health -= 1; // Decrease health when hit by a bullet
            UpdateHealthImages(); // Refresh the health UI
            CanonGamemanager.Instance.OnHealthChanged(); // Notify the game manager

            if (health <= 0)
            {
                gameObject.SetActive(false); // Deactivate the cannon when health is depleted
            }
        }
    }

    void UpdateHealthImages()
    {
        // Update the health images based on the current health
        //img1.SetActive(health >= 1);
        //img2.SetActive(health >= 2);
        //img3.SetActive(health >= 3);
    }
}
