using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenMovement : MonoBehaviour
{
    // Variables for moving up and down
    [SerializeField] private float verticalAmplitude;
    [SerializeField] private float verticalFrequency;

    // Update is called once per frame
    void Update()
    {
        // Eel moves up and down a little bit, like it is floating in place
        float verticalOffset = Mathf.Sin(Time.time * verticalFrequency) * verticalAmplitude;
        transform.Translate(Vector3.up * verticalOffset * Time.deltaTime);
    }
}
