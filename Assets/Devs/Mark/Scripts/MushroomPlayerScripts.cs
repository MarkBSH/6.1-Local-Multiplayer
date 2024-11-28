using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            players[i].GetComponent<MainMovement>().movementSpeed = 26;
            players[i].GetComponent<MainMovement>().jumpForce = 700;
            players[i].GetComponent<MainMovement>().movementMax = 9;
            players[i].GetComponent<PlayerDeathScript>().deathTimer = 1;
            players[i].GetComponent<PlayerDeathScript>().deathParticals = waterParticals;
            players[i].GetComponent<PlayerHitScript>().hitEvent.AddListener(() => players[i].GetComponent<PlayerDeathScript>().DeathEvent());
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < CosmeticsSpawner.Instance.players.Length; i++)
        {
            players[i].GetComponent<MainMovement>().enabled = true;
            players[i].GetComponent<MainMovement>().movementSpeed = 26;
            players[i].GetComponent<MainMovement>().jumpForce = 700;
            players[i].GetComponent<MainMovement>().movementMax = 9;
            players[i].GetComponent<PlayerDeathScript>().deathTimer = 1;
            players[i].GetComponent<PlayerDeathScript>().deathParticals = waterParticals;
            players[i].GetComponent<PlayerHitScript>().hitEvent.AddListener(() => players[i].GetComponent<PlayerDeathScript>().DeathEvent());
        }
    }
}
