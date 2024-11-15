using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomPlayerScripts : MonoBehaviour
{
    GameObject[] players;

    [SerializeField] GameObject waterParticals;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < CosmeticsSpawner.Instance.players.Length; i++)
        {
            players[i].GetComponent<MainMovement>().enabled = true;
            players[i].GetComponent<MainMovement>().movementSpeed = 14;
            players[i].GetComponent<MainMovement>().jumpForce = 400;
            players[i].GetComponent<PlayerDeathScript>().deathTimer = 3;
            players[i].GetComponent<PlayerDeathScript>().deathParticals = waterParticals;
            players[i].GetComponent<TaserAttack>().enabled = true;
        }
    }
}
