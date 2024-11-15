using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ronddraaiding : MonoBehaviour
{
    public Transform draaiding;
    public float rotationSpeed = 1f;  

    public bool EnableRotation = true;
    private void FixedUpdate()
    {
        if (EnableRotation == true)
        {
            draaiding.Rotate(0, 0, rotationSpeed);
        }
        
    }
}
