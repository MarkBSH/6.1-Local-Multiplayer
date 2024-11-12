using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMovement : MonoBehaviour
{
    Rigidbody m_RB;
    public float movementSpeed = 10;
    public float jumpForce = 10;
    Vector2 moveDir;

    void Start()
    {
        m_RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        m_RB.AddForce(new Vector3(moveDir.x * movementSpeed, 0, moveDir.y * movementSpeed), ForceMode.Force);
    }

    public void GetMovement(InputAction.CallbackContext _context)
    {
        moveDir = _context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            m_RB.AddExplosionForce(jumpForce, transform.up, 2f, 2f, ForceMode.Impulse);
        }
    }
}
