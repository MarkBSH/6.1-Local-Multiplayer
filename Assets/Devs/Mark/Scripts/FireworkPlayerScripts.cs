using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
            players[i].GetComponent<MainMovement>().enabled = false;
            players[i].GetComponent<PlayerFirework>().enabled = true;
            playerInput[i] = players[i].GetComponent<PlayerInput>();
            playerInput[i].SwitchCurrentActionMap("Fireworks");
        }
    }
}
