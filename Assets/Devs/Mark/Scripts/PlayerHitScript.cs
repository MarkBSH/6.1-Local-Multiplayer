using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHitScript : MonoBehaviour
{
    public UnityEvent hitEvent;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathHitbox"))
        {
            hitEvent.Invoke();
        }
    }
}
