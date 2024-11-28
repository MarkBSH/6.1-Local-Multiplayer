using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMovement : MonoBehaviour
{
    Rigidbody m_RB; //< rigidbody of the player
    Animator playerAnimator; //< animator of the player
    public Animator skinAnimator; //< animator of the skin
    Vector2 moveDir; //< the directon of where the player is going
    public float movementSpeed; //< the speed of the player
    public float movementMax; //< the maximum speed of the player
    public float jumpForce; //< the jumpforce of the player
    public bool canJump; //< check for if the player can jump
    float jumpCooldown = 0.2f; //< a cooldown for the jumping for no continuus jumping
    float jumpTimer = 0; //< a float variable for ^

    void Start()
    {
        //getting the components
        m_RB = GetComponent<Rigidbody>();
        playerAnimator = transform.GetChild(0).GetComponent<Animator>();
    }

    void Update()
    {
        //add force for movement
        m_RB.AddForce(new Vector3(moveDir.x * movementSpeed * (Time.deltaTime * 60), 0, moveDir.y * movementSpeed * (Time.deltaTime * 60)), ForceMode.Force);
        //limiting the speed of the player
        if (m_RB.velocity.x > movementMax || m_RB.velocity.z > movementMax || m_RB.velocity.x < -movementMax || m_RB.velocity.z < -movementMax)
        {
            m_RB.velocity = m_RB.velocity.normalized * movementMax;
        }
        //rotating the player via the velocity
        if (m_RB.velocity.x > 0.1f || m_RB.velocity.z > 0.1f || m_RB.velocity.x < -0.1f || m_RB.velocity.z < -0.1f)
        {
            gameObject.transform.forward = new(m_RB.velocity.x, 0, m_RB.velocity.z);
        }
        //jump cooldown timer
        if (jumpTimer <= jumpCooldown)
        {
            jumpTimer += Time.deltaTime;
        }
    }

    //setting the skin animator
    public void SetAnimator()
    {
        if (GetComponent<MainMenuPlayer>().selectedSkin != 0)
        {
            skinAnimator = transform.GetChild(0).transform.GetChild(GetComponent<MainMenuPlayer>().selectedSkin).GetComponent<Animator>();
        }
    }

    public void GetMovement(InputAction.CallbackContext _context)
    {
        //getting the vector 2 form the input system and setting the animators for if the player is moving
        moveDir = _context.ReadValue<Vector2>();
        if (_context.performed)
        {
            playerAnimator.SetBool("Move", true);
            if (GetComponent<MainMenuPlayer>().selectedSkin != 0)
            {
                skinAnimator.SetBool("Move", true);
            }
        }
        if (_context.canceled)
        {
            playerAnimator.SetBool("Move", false);
            if (GetComponent<MainMenuPlayer>().selectedSkin != 0)
            {
                skinAnimator.SetBool("Move", false);
            }
        }
    }

    public void Jump(InputAction.CallbackContext _context)
    {
        //add force for jumping and starting the jump animation
        if (_context.performed && canJump && jumpTimer >= jumpCooldown)
        {
            m_RB.AddForce(transform.up * jumpForce);
            jumpTimer = 0;
            playerAnimator.SetTrigger("Jump");
            if (GetComponent<MainMenuPlayer>().selectedSkin != 0)
            {
                skinAnimator.SetTrigger("Jump");
            }
        }
    }
    //if the player is on the groud you can jump
    void OnTriggerStay(Collider other)
    {
        canJump = true;
    }
    //if the player isn't on the groud you can't jump
    void OnTriggerExit(Collider other)
    {
        canJump = false;
    }
}
