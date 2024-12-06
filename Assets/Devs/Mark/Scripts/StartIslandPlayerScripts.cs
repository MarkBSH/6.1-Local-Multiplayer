using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartIslandPlayerScripts : MonoBehaviour
{
    GameObject[] players; // Array of player game objects
    PlayerInput[] playerInput; // Array of player input components

    void Start()
    {
        // Find all players in the scene and initialize their inputs
        players = GameObject.FindGameObjectsWithTag("Player");
        playerInput = new PlayerInput[players.Length];

        for (int i = 0; i < CosmeticsSpawner.Instance.players.Length; i++)
        {
            // Subscribe to scene loaded event and configure player components
            SceneManager.sceneLoaded += OnSceneLoaded;
            playerInput[i] = players[i].GetComponent<PlayerInput>();
            playerInput[i].SwitchCurrentActionMap("Main");
            players[i].GetComponent<PlayerChooseGame>().chosenGame = "";
            players[i].GetComponent<MainMovement>().enabled = true;
            players[i].GetComponent<MainMovement>().movementSpeed = 30;
            players[i].GetComponent<MainMovement>().jumpForce = 650;
            players[i].GetComponent<MainMovement>().movementMax = 16;
            players[i].GetComponent<MainMenuPlayer>().enabled = false;
            players[i].GetComponent<WindUpInput>().enabled = false;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Re-initialize players and their inputs when a new scene is loaded
        players = GameObject.FindGameObjectsWithTag("Player");
        playerInput = new PlayerInput[players.Length];

        for (int i = 0; i < CosmeticsSpawner.Instance.players.Length; i++)
        {
            // Configure player components for the new scene
            playerInput[i] = players[i].GetComponent<PlayerInput>();
            playerInput[i].SwitchCurrentActionMap("Main");
            players[i].GetComponent<PlayerChooseGame>().chosenGame = "";
            players[i].GetComponent<MainMovement>().enabled = true;
            players[i].GetComponent<MainMovement>().movementSpeed = 30;
            players[i].GetComponent<MainMovement>().jumpForce = 650;
            players[i].GetComponent<MainMovement>().movementMax = 16;
            players[i].GetComponent<MainMenuPlayer>().enabled = false;
            players[i].GetComponent<WindUpInput>().enabled = false;
        }
    }
}
