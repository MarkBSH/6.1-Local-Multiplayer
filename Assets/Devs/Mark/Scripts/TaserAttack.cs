using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TaserAttack : MonoBehaviour
{
    [SerializeField] GameObject taserObject;

    float attackTimer;
    [SerializeField] float attackCooldown = 3;

    void Update()
    {
        if (attackTimer <= attackCooldown)
        {
            attackTimer += Time.deltaTime;
        }
    }

    public void Attack(InputAction.CallbackContext _context)
    {
        if (attackTimer > attackCooldown)
        {
            Instantiate(taserObject, transform.position, Quaternion.identity);
            attackTimer = 0;
        }
    }
}
