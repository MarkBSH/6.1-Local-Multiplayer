using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDeletion : MonoBehaviour
{
    void Update()
    {
        if (transform.position.z < -2)
        {
            Destroy(gameObject);
        }
    }
}
