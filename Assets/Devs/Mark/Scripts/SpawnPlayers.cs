using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    GameObject[] players;
    [SerializeField] Vector3[] spawnLocations;

    [SerializeField] bool isMainIsland = false;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < CosmeticsSpawner.Instance.spawningPlayers; i++)
        {
            players[i].transform.position = spawnLocations[i];
        }

        if (isMainIsland)
        {
            MinigameChooser.Instance.PlayerSetup();
            ScoreManager.Instance.FindAndSetTexts();
        }
    }
}
