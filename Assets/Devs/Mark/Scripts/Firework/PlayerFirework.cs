using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerFirework : MonoBehaviour
{
    Animator playerAnimator; // Animator component for the player

    [SerializeField] bool startWalking = false; // Indicates if the player should start walking
    Vector3 startLocation; // Starting position of the player
    [SerializeField] Vector3[] endLocations; // End positions for the player to walk to
    float walkTimer; // Timer controlling the walk animation
    int chosenFirework; // Index of the chosen firework
    bool hasChosen = false; // Indicates if the player has made a choice

    void Start()
    {
        // Get the player's animator component from the first child
        playerAnimator = transform.GetChild(0).GetComponent<Animator>();
    }

    public void ResetStats()
    {
        // Reset player state variables
        startWalking = false;
        walkTimer = 0;
        hasChosen = false;
    }

    void Update()
    {
        if (startWalking && SceneManager.GetActiveScene().name == "FireworkMinigame")
        {
            if (walkTimer > 1)
            {
                // Stop walking animation when destination is reached
                playerAnimator.SetBool("Move", false);
                if (GetComponent<MainMenuPlayer>().selectedSkin != 0)
                {
                    GetComponent<MainMovement>().skinAnimator.SetBool("Move", false);
                }
            }
            else
            {
                // Move the player towards the chosen firework
                transform.position = Vector3.Slerp(startLocation, endLocations[chosenFirework], walkTimer);
                walkTimer += Time.deltaTime / 3;
                playerAnimator.SetBool("Move", true);
                if (GetComponent<MainMenuPlayer>().selectedSkin != 0)
                {
                    GetComponent<MainMovement>().skinAnimator.SetBool("Move", true);
                }
            }
        }
    }

    public void ChooseFirework1(InputAction.CallbackContext _context)
    {
        // Handle selection of the first firework
        if (_context.performed && FireworkMinigameManager.Instance.chosenFirework[0] == 0 && !hasChosen)
        {
            FireworkMinigameManager.Instance.chosenFirework[0] = GetComponent<MainMenuPlayer>().playerNum + 1;
            startWalking = true;
            startLocation = transform.position;
            hasChosen = true;
            chosenFirework = 0;
        }
    }

    public void ChooseFirework2(InputAction.CallbackContext _context)
    {
        // Handle selection of the second firework
        if (_context.performed && FireworkMinigameManager.Instance.chosenFirework[1] == 0 && !hasChosen)
        {
            FireworkMinigameManager.Instance.chosenFirework[1] = GetComponent<MainMenuPlayer>().playerNum + 1;
            startWalking = true;
            startLocation = transform.position;
            hasChosen = true;
            chosenFirework = 1;
        }
    }

    public void ChooseFirework3(InputAction.CallbackContext _context)
    {
        // Handle selection of the third firework
        if (_context.performed && FireworkMinigameManager.Instance.chosenFirework[2] == 0 && !hasChosen)
        {
            FireworkMinigameManager.Instance.chosenFirework[2] = GetComponent<MainMenuPlayer>().playerNum + 1;
            startWalking = true;
            startLocation = transform.position;
            hasChosen = true;
            chosenFirework = 2;
        }
    }

    public void ChooseFirework4(InputAction.CallbackContext _context)
    {
        // Handle selection of the fourth firework
        if (_context.performed && FireworkMinigameManager.Instance.chosenFirework[3] == 0 && !hasChosen)
        {
            FireworkMinigameManager.Instance.chosenFirework[3] = GetComponent<MainMenuPlayer>().playerNum + 1;
            startWalking = true;
            startLocation = transform.position;
            hasChosen = true;
            chosenFirework = 3;
        }
    }
}
