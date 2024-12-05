using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkAudio : MonoBehaviour
{
    [SerializeField] GameObject fireworkAudio;

    void Start()
    {
        Instantiate(fireworkAudio, transform.position, transform.rotation);
    }
}
