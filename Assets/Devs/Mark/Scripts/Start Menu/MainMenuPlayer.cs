using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenuPlayer : MonoBehaviour
{
    public bool isReady = false; //< check if player is ready
    public int playerNum; //< int for when the player has joined
    public int selectedSkin = 0; //< int for the skin selected

    Vector2 moveDir; //< a vector2 to hold the movement keys input to move the player skin preview

    void Start()
    {
        MainMenu.Instance.UpdateCosmVisuals();
    }

    void Update()
    {
        //moves the player inside the skin selector screen
        MainMenu.Instance.skinSelector[playerNum].transform.forward = new(moveDir.x, 0, moveDir.y);
    }

    //gets a vector2 from the movement keys
    public void GetMovement(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            moveDir = _context.ReadValue<Vector2>();
        }
    }

    //ready up for the game
    public void ReadyUp(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            isReady = true;
        }
    }

    //changes skinlist up
    public void ScrollUp(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            selectedSkin--;
            if (selectedSkin < 0)
            {
                selectedSkin = MainMenu.Instance.totalSkins - 1;
            }
            MainMenu.Instance.UpdateCosmVisuals();
        }
    }

    //changes skinlist down
    public void ScrollDown(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            selectedSkin++;
            if (selectedSkin > MainMenu.Instance.totalSkins - 1)
            {
                selectedSkin = 0;
            }
            MainMenu.Instance.UpdateCosmVisuals();
        }
    }
}
