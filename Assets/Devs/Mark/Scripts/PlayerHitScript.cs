using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHitScript : MonoBehaviour
{
    public UnityEvent hitEvent; // Event triggered when the player is hit

    void OnTriggerEnter(Collider other)
    {
        // Invoke the hit event if collided with a death hitbox
        if (other.CompareTag("DeathHitbox"))
        {
            hitEvent.Invoke();
        }
    }
}
