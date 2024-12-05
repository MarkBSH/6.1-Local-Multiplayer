using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class playerwhere : MonoBehaviour
{
    public int whatbutton = 0;
    public Animator[] animators;
    public int howmanybuttins;
    public int playernum;
    public Countdown4 Countdown4;
    public GameObject[] players;
    public GameObject[] players2;
    public GameObject boembeffect;
    public TMP_Text[] texts;
    public AudioSource audioSource;
    // To keep track of players still in the game
    private List<GameObject> activePlayers;

    public void Start()
    {
        randomplayer();
        StartCoroutine(Countdown4.StartCountdown2());
        activePlayers = new List<GameObject>(players);  // Initialize the list with all players
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
        }
        else
        {
            boemb();
        }
    }

    public async void boemb()
    {
        Debug.Log("boemb no way it did the boem thingy OMGGGGGG");
        audioSource.Play();
        Instantiate(boembeffect);
        resetbutton();

        // Deactivate the current player
        activePlayers.Remove(players[playernum]);
        players[playernum].SetActive(false);

        // Check if there's only one player left
        if (activePlayers.Count <= 1)
        {
            Debug.Log("win: " + activePlayers[0].name + " is the last player standing!");
            MainMenuPlayer player = activePlayers[0].GetComponent<MainMenuPlayer>();
            int number = player.playerNum;
            switch (number)
            {
                case 0:
                    ScoreManager.Instance.AddPoints("P1");
                    break;
                case 1:
                    ScoreManager.Instance.AddPoints("P2");
                    break;
                case 2:
                    ScoreManager.Instance.AddPoints("P3");
                    break;
                case 3:
                    ScoreManager.Instance.AddPoints("P4");
                    break;
            }
            await Task.Delay(2000);
            SceneManager.LoadScene("MarkMain");
            CosmeticsSpawner.Instance.ActivatePlayers();
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
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = "";
        }

        players = GameObject.FindGameObjectsWithTag("Player");
        players2 = GameObject.FindGameObjectsWithTag("Player");

        // Initialize the active players list
        activePlayers = new List<GameObject>(players);

        playernum = Random.Range(0, players.Length);
        texts[playernum].text = "pick a detentor";
        Debug.Log("player " + playernum + " will boemb first");

    }

    public void nextplayer()
    {
        if (playernum >= players.Length)
        {
            playernum = 0;
        }
        else
        {
            playernum++;
        }
    }
}
