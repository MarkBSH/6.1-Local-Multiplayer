using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMovement : MonoBehaviour
{
    Rigidbody m_RB;
    Animator playerAnimator;
    Animator skinAnimator;
    Vector2 moveDir;
    public float movementSpeed;
    public float movementMax;
    public float jumpForce;
    bool canJump;
    float jumpCooldown = 0.2f;
    float jumpTimer = 0;

    public float stunTimer;

    void Start()
    {
        m_RB = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        skinAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (stunTimer <= 0)
        {
            m_RB.AddForce(new Vector3(moveDir.x * movementSpeed * (Time.deltaTime * 60), 0, moveDir.y * movementSpeed * (Time.deltaTime * 60)), ForceMode.Force);
            if (m_RB.velocity.x > movementMax || m_RB.velocity.z > movementMax || m_RB.velocity.x < -movementMax || m_RB.velocity.z < -movementMax)
            {
                m_RB.velocity = m_RB.velocity.normalized * movementMax;
            }
        }
        if (moveDir.x != 0 || moveDir.y != 0)
        {
            gameObject.transform.forward = new(moveDir.x, 0, moveDir.y);
        }

        if (jumpTimer <= jumpCooldown)
        {
            jumpTimer += Time.deltaTime;
        }

        if (stunTimer > 0)
        {
            stunTimer -= Time.deltaTime;
        }
    }

    public void GetMovement(InputAction.CallbackContext _context)
    {
        moveDir = _context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext _context)
    {
        if (_context.performed && canJump && jumpTimer >= jumpCooldown && stunTimer <= 0)
        {
            m_RB.AddForce(transform.up * jumpForce);
            jumpTimer = 0;
        }
    }

    void OnTriggerStay(Collider other)
    {
        canJump = true;
    }

    void OnTriggerExit(Collider other)
    {
        canJump = false;
    }
}
