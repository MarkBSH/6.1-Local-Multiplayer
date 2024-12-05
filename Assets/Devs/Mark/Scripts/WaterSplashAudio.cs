using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplashAudio : MonoBehaviour
{
    [SerializeField] GameObject splashAudio;

    void Start()
    {
        Instantiate(splashAudio, transform.position, transform.rotation);
    }
}
