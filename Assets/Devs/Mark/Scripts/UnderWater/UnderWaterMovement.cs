using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UnderWaterMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector2 movement;

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "UnderWaterMinigame")
        {
            Vector3 move = new Vector3(movement.x, movement.y, 0) * speed * Time.deltaTime;
            Debug.Log(move * 200);
            UnderWaterManager.Instance.submarines[GetComponent<MainMenuPlayer>().playerNum].GetComponent<Rigidbody>().velocity = move * 200;
        }
    }

    public void GetMovement(InputAction.CallbackContext _context)
    {
        movement = _context.ReadValue<Vector2>();
    }
}
