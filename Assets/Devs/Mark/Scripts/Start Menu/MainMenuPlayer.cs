using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenuPlayer : MonoBehaviour
{
    public bool isReady = false;
    public int playerNum;
    public int selectedSkin = 0;

    Vector2 moveDir;

    void Start()
    {
        MainMenu.Instance.UpdateCosmVisuals();
    }

    void Update()
    {
        MainMenu.Instance.skinSelector[playerNum].transform.forward = new(moveDir.x, 0, moveDir.y);
    }

    public void GetMovement(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            moveDir = _context.ReadValue<Vector2>();
        }
    }

    public void ReadyUp(InputAction.CallbackContext _context)
    {
        if (_context.performed)
        {
            isReady = true;
        }
    }

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
