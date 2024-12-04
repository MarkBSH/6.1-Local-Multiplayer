using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UnderWaterMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector2 movement;

    void Update()
    {

        Vector3 move = new Vector3(-movement.x, movement.y, 0) * speed * Time.deltaTime;
        UnderWaterManager.Instance.submarines[GetComponent<MainMenuPlayer>().playerNum].transform.Translate(move);
    }

    public void GetMovement(InputAction.CallbackContext _context)
    {
        movement = _context.ReadValue<Vector2>();
    }
}
