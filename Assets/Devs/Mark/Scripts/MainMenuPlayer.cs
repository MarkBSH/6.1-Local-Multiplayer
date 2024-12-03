using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenuPlayer : MonoBehaviour
{
    public bool isReady = false; // Indicates if the player is ready
    public int playerNum; // The player's number
    public int selectedSkin = 0; // Index of the selected skin

    public int PlayerNum
    {
        get { return playerNum; }
    }

    Vector2 moveDir; // Direction for moving the skin preview

    void Start()
    {
        MainMenu.Instance.UpdateCosmVisuals(); // Update cosmetic visuals
    }

    void Update()
    {
        // Rotate the skin preview based on input
        MainMenu.Instance.skinSelector[playerNum].transform.forward = new Vector3(moveDir.x, 0, moveDir.y);
    }

    public void GetMovement(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            moveDir = _context.ReadValue<Vector2>(); // Get movement input
        }
    }

    public void ReadyUp(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            isReady = true; // Set the player as ready
        }
    }

    public void ScrollUp(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            selectedSkin--; // Decrement the skin index
            if (selectedSkin < 0)
            {
                selectedSkin = MainMenu.Instance.totalSkins - 1; // Loop to the last skin
            }
            MainMenu.Instance.UpdateCosmVisuals(); // Update cosmetic visuals
        }
    }

    public void ScrollDown(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            selectedSkin++; // Increment the skin index
            if (selectedSkin > MainMenu.Instance.totalSkins - 1)
            {
                selectedSkin = 0; // Loop to the first skin
            }
            MainMenu.Instance.UpdateCosmVisuals(); // Update cosmetic visuals
        }
    }
}
