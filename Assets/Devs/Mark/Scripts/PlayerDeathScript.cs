using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{
    public float deathTimer;
    public GameObject deathParticals;

    // Handles the player's death event
    public void DeathEvent()
    {
        Instantiate(deathParticals, transform.position, Quaternion.identity);
        StartCoroutine(DeathCooldown());
    }

    // Waits for a specified time before deactivating the player
    IEnumerator DeathCooldown()
    {
        yield return new WaitForSeconds(deathTimer);
        gameObject.SetActive(false);
    }
}
