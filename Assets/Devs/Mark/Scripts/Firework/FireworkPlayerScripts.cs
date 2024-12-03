using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FireworkPlayerScripts : MonoBehaviour
{
    GameObject[] players;
    PlayerInput[] playerInput;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        playerInput = new PlayerInput[players.Length];

        for (int i = 0; i < CosmeticsSpawner.Instance.players.Length; i++)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            playerInput[i] = players[i].GetComponent<PlayerInput>();
            playerInput[i].SwitchCurrentActionMap("Fireworks");
        }
    }

    // Called when a new scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        playerInput = new PlayerInput[players.Length];

        for (int i = 0; i < CosmeticsSpawner.Instance.players.Length; i++)
        {
            playerInput[i] = players[i].GetComponent<PlayerInput>();
            playerInput[i].SwitchCurrentActionMap("Fireworks");
        }
    }
}
