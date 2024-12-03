using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnderWaterMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector2 movement;
    private int playerNum;
    private GameObject submarine;

    public void GetMovement(InputAction.CallbackContext _context)
    {
        movement = _context.ReadValue<Vector2>();
    }

    void Start()
    {
        playerNum = GetComponent<MainMenuPlayer>().playerNum;
        submarine = UnderWaterGameManager.Instance.GetSubmarineByPlayerNum(playerNum);
    }

    void Update()
    {
        if (submarine != null)
        {
            Vector3 move = new Vector3(movement.x, movement.y, 0) * speed * Time.deltaTime;
            submarine.transform.Translate(move);
        }
    }
}
