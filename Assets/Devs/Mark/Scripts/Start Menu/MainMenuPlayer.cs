using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenuPlayer : MonoBehaviour
{
    public bool isReady = false;
    public int playerNum;
    public int SelectedSkin;
    
    public float movementSpeed = 10;
    Vector2 moveDir;

    void Start()
    {
        
    }

    void Update()
    {
        MainMenu.Instance.skinSelector[playerNum].transform.forward = new(moveDir.x, 0 , moveDir.y);
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
}
