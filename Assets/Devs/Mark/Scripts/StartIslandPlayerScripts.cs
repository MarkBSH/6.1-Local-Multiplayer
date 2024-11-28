using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartIslandPlayerScripts : MonoBehaviour
{
    GameObject[] players;
    PlayerInput[] playerInput;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        playerInput = new PlayerInput[players.Length];

        for (int i = 0; i < CosmeticsSpawner.Instance.players.Length; i++)
        {
            playerInput[i] = players[i].GetComponent<PlayerInput>();
            playerInput[i].SwitchCurrentActionMap("Main");
            players[i].GetComponent<PlayerChooseGame>().chosenGame = "";
            players[i].GetComponent<MainMovement>().enabled = true;
            players[i].GetComponent<MainMovement>().movementSpeed = 24;
            players[i].GetComponent<MainMovement>().jumpForce = 650;
            players[i].GetComponent<MainMovement>().movementMax = 10;
            players[i].GetComponent<MainMenuPlayer>().enabled = false;
            players[i].GetComponent<WindUpInput>().enabled = false;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        playerInput = new PlayerInput[players.Length];

        for (int i = 0; i < CosmeticsSpawner.Instance.players.Length; i++)
        {
            playerInput[i] = players[i].GetComponent<PlayerInput>();
            playerInput[i].SwitchCurrentActionMap("Main");
            players[i].GetComponent<PlayerChooseGame>().chosenGame = "";
            players[i].GetComponent<MainMovement>().enabled = true;
            players[i].GetComponent<MainMovement>().canJump = false;
            players[i].GetComponent<MainMovement>().movementSpeed = 24;
            players[i].GetComponent<MainMovement>().jumpForce = 650;
            players[i].GetComponent<MainMovement>().movementMax = 10;
            players[i].GetComponent<MainMenuPlayer>().enabled = false;
            players[i].GetComponent<WindUpInput>().enabled = false;
        }
    }
}
