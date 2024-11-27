using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFirework : MonoBehaviour
{
    Animator playerAnimator; //< animator of the player

    [SerializeField] bool startWalking = false;
    Vector3 startLocation;
    [SerializeField] Vector3[] endLocations;
    float walkTimer;
    [SerializeField] int chosenFirework;
    [SerializeField] bool hasChosen = false;

    void Start()
    {
        playerAnimator = transform.GetChild(0).GetComponent<Animator>();
    }

    void Update()
    {
        if (startWalking)
        {
            if (walkTimer > 1)
            {
                playerAnimator.SetBool("Move", false);
                if (GetComponent<MainMenuPlayer>().selectedSkin != 0)
                {
                    GetComponent<MainMovement>().skinAnimator.SetBool("Move", false);
                }
            }
            else
            {
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
        if (_context.performed && FireworkMinigameManager.Instance.chosenFirework[0] == 0 && !hasChosen)
        {
            FireworkMinigameManager.Instance.chosenFirework[0] = gameObject.GetComponent<MainMenuPlayer>().playerNum + 1;
            startWalking = true;
            startLocation = transform.position;
            hasChosen = true;
            chosenFirework = 0;
        }
    }

    public void ChooseFirework2(InputAction.CallbackContext _context)
    {
        if (_context.performed && FireworkMinigameManager.Instance.chosenFirework[1] == 0 && !hasChosen)
        {
            FireworkMinigameManager.Instance.chosenFirework[1] = gameObject.GetComponent<MainMenuPlayer>().playerNum + 1;
            startWalking = true;
            startLocation = transform.position;
            hasChosen = true;
            chosenFirework = 1;
        }
    }

    public void ChooseFirework3(InputAction.CallbackContext _context)
    {
        if (_context.performed && FireworkMinigameManager.Instance.chosenFirework[2] == 0 && !hasChosen)
        {
            FireworkMinigameManager.Instance.chosenFirework[2] = gameObject.GetComponent<MainMenuPlayer>().playerNum + 1;
            startWalking = true;
            startLocation = transform.position;
            hasChosen = true;
            chosenFirework = 2;
        }
    }

    public void ChooseFirework4(InputAction.CallbackContext _context)
    {
        if (_context.performed && FireworkMinigameManager.Instance.chosenFirework[3] == 0 && !hasChosen)
        {
            FireworkMinigameManager.Instance.chosenFirework[3] = gameObject.GetComponent<MainMenuPlayer>().playerNum + 1;
            startWalking = true;
            startLocation = transform.position;
            hasChosen = true;
            chosenFirework = 3;
        }
    }
}
