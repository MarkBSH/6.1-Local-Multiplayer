using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMovement : MonoBehaviour
{
    Rigidbody m_RB;
    public float movementSpeed = 4;
    Vector2 moveDir;

    void Start()
    {
        m_RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        m_RB.AddForce(new Vector3(moveDir.x * movementSpeed * Time.deltaTime, 0, moveDir.y * movementSpeed * Time.deltaTime), ForceMode.Force);
    }

    public void MoveHorizontal(InputAction.CallbackContext _context)
    {
        moveDir = _context.ReadValue<Vector2>();
    }
}
