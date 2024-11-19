using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ronddraaiding : MonoBehaviour
{
    public Transform draaiding;
    public float rotationSpeed = 1f;
    public bool EnableRotation = true;

    private void Start()
    {
        StartCoroutine(IncreaseSpeed());
    }

    private void FixedUpdate()
    {
        if (EnableRotation)
        {
            draaiding.Rotate(0, rotationSpeed, 0);
        }
    }

    private IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            rotationSpeed += 0.33f;
        }
    }
}
