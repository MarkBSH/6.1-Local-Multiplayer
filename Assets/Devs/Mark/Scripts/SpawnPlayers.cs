using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    GameObject[] players; //< list of player gameobjects
    [SerializeField] Vector3[] spawnLocations; //< list of spawn points
    [SerializeField] bool isMainIsland = false; //< check for if the scene is the main island

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < CosmeticsSpawner.Instance.spawningPlayers; i++)
        {
            //setting every player on a spawn point
            players[i].transform.position = spawnLocations[i];
        }

        // check for main island
        if (isMainIsland)
        {
            //past chosen minigames clearer
            MinigameChooser.Instance.PlayerSetup();
            //setting the scores on screen
            ScoreManager.Instance.FindAndSetTexts();
        }
    }
}
