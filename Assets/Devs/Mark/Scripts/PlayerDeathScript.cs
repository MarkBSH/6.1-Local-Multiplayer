using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{
    [SerializeField] float deathTimer;
    [SerializeField] GameObject deathParticals;

    public void DeathEvent()
    {
        Instantiate(deathParticals, transform.position, Quaternion.identity);
        Destroy(gameObject, deathTimer);
    }
}
