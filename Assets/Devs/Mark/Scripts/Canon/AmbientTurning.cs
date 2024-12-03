using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientTurning : MonoBehaviour
{
    [SerializeField] private float minTurnSpeed = 1f; // Minimum rotation speed
    [SerializeField] private float maxTurnSpeed = 5f; // Maximum rotation speed
    float turnSpeed; // Current rotation speed

    void Start()
    {
        turnSpeed = Random.Range(minTurnSpeed, maxTurnSpeed); // Randomize rotation speed
    }

    void Update()
    {
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime); // Rotate the object
    }
}
