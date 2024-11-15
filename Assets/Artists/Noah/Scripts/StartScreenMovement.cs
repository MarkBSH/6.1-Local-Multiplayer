using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenMovement : MonoBehaviour
{
    // Variables for moving up and down
    [SerializeField] private float verticalAmplitude;
    [SerializeField] private float verticalFrequency;

    void Start()
    {
        verticalAmplitude = Random.Range(0.6f, 1.4f);
        verticalFrequency = Random.Range(0.6f, 1.4f);
    }

    // Update is called once per frame
    void Update()
    {
        // Eel moves up and down a little bit, like it is floating in place
        float verticalOffset = Mathf.Sin(Time.time * verticalFrequency) * verticalAmplitude;
        transform.Translate(Vector3.up * verticalOffset * Time.deltaTime);
    }
}
