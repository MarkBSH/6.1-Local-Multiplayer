using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class WindUpInput : MonoBehaviour
{
    public Windup windup;
    [SerializeField] private MainMenuPlayer MainMenuPlayer;

    void Start()
    {



    }

    void Update()
    {
        UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (windup == null && sceneName == "windup")
        {
            GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
            if (gameController != null)
            {
                windup = gameController.GetComponent<Windup>();
            }
        }
    }

    public void WindUp(InputAction.CallbackContext _context)
    {
        if (windup != null && _context.performed)
        {
            windup.addScore(MainMenuPlayer.playerNum);
        }
    }
}
