using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartIslandPlayerScripts : MonoBehaviour
{
    GameObject[] players;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < CosmeticsSpawner.Instance.players.Length; i++)
        {
            players[i].GetComponent<PlayerChooseGame>().chosenGame = "";
            players[i].GetComponent<MainMovement>().enabled = true;
            players[i].GetComponent<MainMovement>().movementSpeed = 24;
            players[i].GetComponent<MainMovement>().jumpForce = 650;
            players[i].GetComponent<MainMovement>().movementMax = 10;
            players[i].GetComponent<MainMenuPlayer>().enabled = false;
        }
    }
}
