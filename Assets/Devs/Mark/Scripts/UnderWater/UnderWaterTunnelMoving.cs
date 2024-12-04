using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWaterTunnelMoving : MonoBehaviour
{
    public float speed = 10.0f;

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
