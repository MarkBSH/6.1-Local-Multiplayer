using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CanonAttacking : MonoBehaviour
{
    [SerializeField] float shotCooldown = 2; // Cooldown between shots
    float shotTimer; // Timer to track cooldown

    void Update()
    {
        // Update the shot timer
        if (shotTimer <= shotCooldown)
        {
            shotTimer += Time.deltaTime;
        }
    }

    public void Attack(InputAction.CallbackContext _context)
    {
        if (shotTimer > shotCooldown)
        {
            if (_context.performed)
            {
                shotTimer = 0;
                // Initiate shooting action
                StartCoroutine(
                    CanonGamemanager.Instance.canonHealths[
                        GetComponent<MainMenuPlayer>().playerNum
                    ].GetComponent<CanonTurningAndShooting>().Shoot()
                );
            }
        }
    }
}
