using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
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
            Debug.Log("fortnitem oneys on a ilands");
            GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
            if (gameController != null)
            {
                windup = gameController.GetComponent<Windup>();
                if (windup == null)
                {
                    Debug.LogError("Windup component not found on GameController!");
                }
            }
            else
            {
                Debug.LogError("GameController object not found!");
            }
        }
    }

    public void WindUp(InputAction.CallbackContext _context)
    {
        if (windup != null)
        {
            windup.addSore(MainMenuPlayer.playerNum);
        }
    }
}
