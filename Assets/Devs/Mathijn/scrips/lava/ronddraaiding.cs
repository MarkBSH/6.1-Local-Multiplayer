using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ronddraaiding : MonoBehaviour
{
    public Transform draaiding;
    public float draaispeed = 1f;
    public bool aanHetDraaien = true;

    private void Start()
    {
        StartCoroutine(IncreaseSpeed());
    }

    private void FixedUpdate()
    {
        if (aanHetDraaien)
        {
            draaiding.Rotate(0, draaispeed, 0);
        }
    }

    private IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            draaispeed += 0.33f;
        }
    }
}
