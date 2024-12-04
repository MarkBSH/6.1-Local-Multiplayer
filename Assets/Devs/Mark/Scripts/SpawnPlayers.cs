using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    GameObject[] players; // Array of player game objects
    [SerializeField] Vector3[] spawnLocations; // Spawn positions for players
    [SerializeField] bool isMainIsland = false; // Indicates if the scene is the main island

    void Start()
    {
        // Find all players and set their spawn locations
        players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < CosmeticsSpawner.Instance.spawningPlayers; i++)
        {
            players[i].transform.position = spawnLocations[i];
        }

        // If this is the main island scene, reset player minigame choices and display scores
        if (isMainIsland)
        {
            ScoreManager.Instance.FindAndSetTexts();
        }
    }
}
