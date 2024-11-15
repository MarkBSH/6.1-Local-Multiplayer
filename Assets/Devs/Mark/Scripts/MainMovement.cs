using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMovement : MonoBehaviour
{
    Rigidbody m_RB;
    public float movementSpeed = 10;
    Vector2 moveDir;
    public float jumpForce = 10;
    bool canJump;
    float jumpCooldown = 0.2f;
    float jumpTimer = 0;

    void Start()
    {
        m_RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        m_RB.AddForce(new Vector3(moveDir.x * movementSpeed * (Time.deltaTime * 60), 0, moveDir.y * movementSpeed * (Time.deltaTime * 60)), ForceMode.Force);

        if (jumpTimer <= jumpCooldown)
        {
            jumpTimer += Time.deltaTime;
        }
    }

    public void GetMovement(InputAction.CallbackContext _context)
    {
        moveDir = _context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext _context)
    {
        if (_context.performed && canJump && jumpTimer >= jumpCooldown)
        {
            m_RB.AddForce(transform.up * jumpForce);
            jumpTimer = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        canJump = true;
    }

    void OnTriggerExit(Collider other)
    {
        canJump = false;
    }
}
