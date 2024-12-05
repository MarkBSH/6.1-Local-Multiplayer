using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class playerwhere : MonoBehaviour
{
    public int whatbutton = 0;
    public Animator[] animators;
    public int howmanybuttins;
    public int playernum;
    public Countdown4 Countdown4;
    public GameObject[] players;
    public GameObject boembeffect;
    public TMP_Text[] texts;
    private List<GameObject> playerList = new List<GameObject>();
    public void Start()
    {
        randomplayer();
        StartCoroutine(Countdown4.StartCountdown2());
    }
    public void changebutton(int whatbuttonfunc, int player)
    {
        if (playernum == player)
        {
            whatbutton = whatbuttonfunc;
            Debug.Log(whatbutton);
        }
    }
    public void resetbutton()
    {
        whatbutton = 0;
        for (int i = 0; i < animators.Length; i++) 
        {
            animators[i].SetTrigger("reset");
        }
    }
    public void pressbutton()
    {
        
        if (whatbutton != 0)
        {
            animators[whatbutton - 1].SetTrigger("pushdown");
            if (Random.Range(0, howmanybuttins) == 0)
            {
                
                boemb();
            }
            else
            {
                noboemb();
            }
        } else
        {
            boemb();
        }
    }
    public void boemb()
    {
        Debug.Log("boemb no way it did the boem thingy OMGGGGGG");
        Instantiate(boembeffect);
        resetbutton();

        GameObject playerToRemove = players[playernum];
        playerList.Remove(playerToRemove);  // Remove the player from the list
        playerToRemove.SetActive(false);    // Deactivate the player in the scene

        // Update the players array to reflect the removal
        players = playerList.ToArray();

        if (players.Length > 0)
        {
            randomplayer();
        }
        else
        {
            Debug.Log("No players left!");
        }


    }
    public void noboemb()
    {
        Debug.Log("no boemb");
        resetbutton();
        randomplayer();
    }
    public void randomplayer()
    {
        for (int i = 0;i < texts.Length;i++)
        {
            texts[i].text = "";
        }
        players = GameObject.FindGameObjectsWithTag("Player");
        playernum = Random.Range(0, players.Length);
        texts[playernum].text = "pick a detentor";
        Debug.Log("player " + playernum + "will boemb first");
    }
    public void nextplayer()
    {
        if (playernum >= players.Length)
        {
            playernum = 0;
        } else
        {
            playernum++;
        }
    }
}
