using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWaterHealth : MonoBehaviour
{
    public int playerNum; // The player number of the cannon
    public float health = 3; // Initial health of the cannon
    public GameObject img1; // Reference to the first health image
    public GameObject img2; // Reference to the second health image
    public GameObject img3; // Reference to the third health image

    private bool isInvulnerable = false; // Flag to check invulnerability
    public Animator animator; // Reference to the Animator component

    void Start()
    {
        UpdateHealthImages(); // Initialize the health UI
    }

    void Update()
    {
        // No update logic needed
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UnderWaterHit") && !isInvulnerable)
        {
            health -= 1; // Decrease health when hit by a bullet
            UpdateHealthImages(); // Refresh the health UI
            UnderWaterManager.Instance.OnHealthChanged(); // Notify the game manager

            if (health <= 0)
            {
                gameObject.SetActive(false); // Deactivate the cannon when health is depleted
            }
            else
            {
                StartCoroutine(InvulnerabilityCoroutine()); // Start invulnerability period
            }
        }
    }

    IEnumerator InvulnerabilityCoroutine()
    {
        isInvulnerable = true; // Set invulnerability flag
        animator.SetTrigger("Flash"); // Play hit animation
        yield return new WaitForSeconds(1f); // Wait for 1 second
        isInvulnerable = false; // Reset invulnerability flag
    }

    void UpdateHealthImages()
    {
        // Update the health images based on the current health
        img1.SetActive(health >= 1);
        img2.SetActive(health >= 2);
        img3.SetActive(health >= 3);
    }
}
