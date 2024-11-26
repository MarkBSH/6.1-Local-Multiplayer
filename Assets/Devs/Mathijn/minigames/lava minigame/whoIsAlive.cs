using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class whoIsAlive : MonoBehaviour
{
    public GameObject[] players;
    public GameObject[] playersAlive;
    public TextMeshProUGUI[] texts;
    private int numberOfAlivePlayers;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        playersAlive = new GameObject[players.Length];  
        numberOfAlivePlayers = players.Length;

        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<MainMovement>().enabled = true;
            players[i].GetComponent<MainMovement>().movementSpeed = 18;
            players[i].GetComponent<MainMovement>().jumpForce = 400;
            players[i].GetComponent<MainMovement>().movementMax = 6;
            players[i].GetComponent<PlayerHitScript>().hitEvent.AddListener(() => player(players[i])); 

            playersAlive[i] = players[i];
        }
    }

    void Update()
    {
        playersAlive = GameObject.FindGameObjectsWithTag("Player");
        numberOfAlivePlayers = playersAlive.Length;

        Debug.Log(numberOfAlivePlayers + " players left");

        if (numberOfAlivePlayers == 1)
        {
            Debug.Log("One player left!");
        }
    }

    public void player(GameObject player)
    {
        Debug.Log("theo is dik");
        for (int i = 0; i < players.Length; i++)
        {
            if (player == players[i])
            {
                texts[i].text = numberOfAlivePlayers + " players left";  
            }
        }
    }
}
