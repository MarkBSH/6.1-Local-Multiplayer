using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] GameObject[] players;
    [SerializeField] Vector3[] spawnLocations;

    void Start()
    {
        for (int i = 0; i < CosmeticsSpawner.Instance.spawningPlayers; i++)
        {
            Instantiate(players[i], spawnLocations[i], Quaternion.identity);
            CosmeticsSpawner.Instance.PlaceCosmetics();
            MinigameChooser.Instance.PlayerSetup();
        }
    }
}