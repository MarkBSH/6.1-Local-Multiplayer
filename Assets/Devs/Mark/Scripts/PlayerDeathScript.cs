using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{
    public float deathTimer;
    public GameObject deathParticals;

    public void DeathEvent()
    {
        Instantiate(deathParticals, transform.position, Quaternion.identity);
        StartCoroutine(DeathCooldown());
    }

    IEnumerator DeathCooldown()
    {
        yield return new WaitForSeconds(deathTimer);
        gameObject.SetActive(false);
    }
}
