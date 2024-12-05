using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMovement : MonoBehaviour
{
    Rigidbody m_RB; // Rigidbody of the player
    Animator playerAnimator; // Animator of the player
    public Animator skinAnimator; // Animator of the skin
    Vector2 moveDir; // Direction of movement
    public float movementSpeed; // Movement speed
    public float movementMax; // Maximum speed
    public float jumpForce; // Jump force
    public bool canJump; // Indicates if the player can jump
    float jumpCooldown = 0.2f; // Cooldown between jumps
    float jumpTimer = 0; // Timer for jump cooldown
    [SerializeField] GameObject jumpAudio; // Jump sound effect
    [SerializeField] AudioSource moveAudio; // Movement sound effect

    void Start()
    {
        m_RB = GetComponent<Rigidbody>();
        playerAnimator = transform.GetChild(0).GetComponent<Animator>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Actions to perform when a new scene is loaded
        canJump = false;
    }

    void Update()
    {
        // Apply movement force
        m_RB.AddForce(new Vector3(
            moveDir.x * movementSpeed * (Time.deltaTime * 60),
            0,
            moveDir.y * movementSpeed * (Time.deltaTime * 60)
        ), ForceMode.Force);

        // Limit the player's speed
        if (m_RB.velocity.magnitude > movementMax)
        {
            m_RB.velocity = m_RB.velocity.normalized * movementMax;
        }

        // Rotate player to face movement direction
        if (m_RB.velocity.magnitude > 0.1f)
        {
            transform.forward = new Vector3(m_RB.velocity.x, 0, m_RB.velocity.z);
        }

        // Play or stop movement audio based on moveDir
        if (moveDir != Vector2.zero)
        {
            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
        }
        else
        {
            if (moveAudio.isPlaying)
            {
                moveAudio.Stop();
            }
        }

        // Increment jump timer
        if (jumpTimer <= jumpCooldown)
        {
            jumpTimer += Time.deltaTime;
        }
    }

    // Sets the animator based on selected skin
    public void SetAnimator()
    {
        if (GetComponent<MainMenuPlayer>().selectedSkin != 0)
        {
            skinAnimator = transform.GetChild(0)
                .GetChild(GetComponent<MainMenuPlayer>().selectedSkin)
                .GetComponent<Animator>();
        }
    }

    // Handles movement input
    public void GetMovement(InputAction.CallbackContext _context)
    {
        moveDir = _context.ReadValue<Vector2>();
        if (_context.performed)
        {
            playerAnimator.SetBool("Move", true);
            if (skinAnimator != null)
            {
                skinAnimator.SetBool("Move", true);
            }
        }
        if (_context.canceled)
        {
            playerAnimator.SetBool("Move", false);
            if (skinAnimator != null)
            {
                skinAnimator.SetBool("Move", false);
            }
        }
    }

    // Handles jump input
    public void Jump(InputAction.CallbackContext _context)
    {
        if (_context.performed && canJump && jumpTimer >= jumpCooldown)
        {
            m_RB.AddForce(Vector3.up * jumpForce, ForceMode.Force);
            jumpTimer = 0;
            playerAnimator.SetTrigger("Jump");
            if (skinAnimator != null)
            {
                skinAnimator.SetTrigger("Jump");
            }
            Instantiate(jumpAudio, transform.position, Quaternion.identity);
        }
    }

    // Called when entering a trigger collider
    void OnTriggerEnter(Collider other)
    {
        canJump = true;
    }

    // Called when exiting a trigger collider
    void OnTriggerExit(Collider other)
    {
        canJump = false;
    }
}
