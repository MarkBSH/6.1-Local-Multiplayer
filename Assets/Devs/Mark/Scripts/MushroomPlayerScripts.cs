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
            SceneManager.sceneLoaded += OnSceneLoaded;
            var playerMovement = players[i].GetComponent<MainMovement>();
            playerMovement.enabled = true;
            playerMovement.movementSpeed = 26;
            playerMovement.jumpForce = 700;
            playerMovement.movementMax = 9;

            var playerDeath = players[i].GetComponent<PlayerDeathScript>();
            playerDeath.deathTimer = 1;
            playerDeath.deathParticals = waterParticals;

            players[i].GetComponent<PlayerHitScript>().hitEvent.AddListener(() => playerDeath.DeathEvent());
        }
    }

    // Called when a new scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < CosmeticsSpawner.Instance.players.Length; i++)
        {
            var playerMovement = players[i].GetComponent<MainMovement>();
            playerMovement.enabled = true;
            playerMovement.movementSpeed = 26;
            playerMovement.jumpForce = 700;
            playerMovement.movementMax = 9;

            var playerDeath = players[i].GetComponent<PlayerDeathScript>();
            playerDeath.deathTimer = 1;
            playerDeath.deathParticals = waterParticals;

            players[i].GetComponent<PlayerHitScript>().hitEvent.AddListener(() => playerDeath.DeathEvent());
        }
    }
}
