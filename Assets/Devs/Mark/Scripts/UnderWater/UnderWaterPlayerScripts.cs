using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UnderWaterPlayerScripts : MonoBehaviour
{
    GameObject[] players;
    PlayerInput[] playerInput;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        playerInput = new PlayerInput[players.Length]; // Initialize the array

        for (int i = 0; i < CosmeticsSpawner.Instance.players.Length; i++)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            playerInput[i] = players[i].GetComponent<PlayerInput>();
            playerInput[i].SwitchCurrentActionMap("UnderWater");
        }
    }

    // Called when a new scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        playerInput = new PlayerInput[players.Length]; // Initialize the array

        for (int i = 0; i < CosmeticsSpawner.Instance.players.Length; i++)
        {
            playerInput[i] = players[i].GetComponent<PlayerInput>();
            playerInput[i].SwitchCurrentActionMap("UnderWater");
        }
    }
}
