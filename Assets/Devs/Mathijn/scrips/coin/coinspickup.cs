using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class coinspickup : MonoBehaviour
{
    public coimmager coimmager;
    [SerializeField] private MainMenuPlayer MainMenuPlayer;
    // Start is called before the first frame update
    void Update()
    {
        UnityEngine.SceneManagement.Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (coimmager == null && sceneName == "coinminigame")
        {
            Debug.Log("fortnitem oneys on a ilands 2");
            GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
            if (gameController != null)
            {
                coimmager = gameController.GetComponent<coimmager>();
            }
        }
    }

}
