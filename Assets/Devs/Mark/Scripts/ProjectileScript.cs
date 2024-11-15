using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] float velocitySpeed = 10;

    void Update()
    {
        transform.Translate(transform.forward * velocitySpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<MainMovement>().stunTimer = 0.8f;
        }
        Destroy(gameObject);
    }
}
