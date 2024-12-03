using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CanonAttacking : MonoBehaviour
{
    public void Attack(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            // Initiate shooting action
            StartCoroutine(
                CanonGamemanager.Instance.canonHealths[
                    GetComponent<MainMenuPlayer>().playerNum
                ].GetComponent<CanonTurningAndShooting>().Shoot()
            );
        }
    }
}
