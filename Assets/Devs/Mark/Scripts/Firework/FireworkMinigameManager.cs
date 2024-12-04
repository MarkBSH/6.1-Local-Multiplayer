using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireworkMinigameManager : MonoBehaviour
{
    private static FireworkMinigameManager m_Instance;
    public static FireworkMinigameManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<FireworkMinigameManager>();
            }
            return m_Instance;
        }
    }

    GameObject[] players;
    public int[] chosenFirework = new int[4];
    [SerializeField] GameObject[] fireworks;
    [SerializeField] GameObject[] fireworkPlacements;
    int chosenWinner;
    bool hasEnded = false;
    GameObject canvas;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        players = GameObject.FindGameObjectsWithTag("Player");
        canvas = GameObject.Find("canvas");
    }

    // Resets variables when a new scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        chosenFirework = new int[4];
        hasEnded = false;
        players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<PlayerFirework>().ResetStats();
        }
    }

    void Update()
    {
        int totalChosenFireworks = 0;
        for (int i = 0; i < chosenFirework.Length; i++)
        {
            if (chosenFirework[i] != 0)
            {
                totalChosenFireworks++;
            }
        }

        if (totalChosenFireworks == CosmeticsSpawner.Instance.players.Length && !hasEnded)
        {
            chosenWinner = Random.Range(0, chosenFirework.Length);
            if (chosenFirework[chosenWinner] != 0)
            {
                StartCoroutine(EndGame());
                hasEnded = true;
            }
        }
    }

    // Handles the end of the minigame
    IEnumerator EndGame()
    {
        CamZoomToWinner.Instance.CamLookUp();
        canvas.SetActive(false);
        yield return new WaitForSeconds(1f);

        // Instantiate fireworks for each player
        for (int i = 0; i < chosenFirework.Length; i++)
        {
            if (chosenFirework[i] != 0)
            {
                if (i == chosenWinner)
                {
                    Instantiate(fireworks[0], fireworkPlacements[i].transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(fireworks[Random.Range(1, 4)], fireworkPlacements[i].transform.position, Quaternion.identity);
                }
                fireworkPlacements[i].GetComponent<Animator>().SetTrigger("Start");
            }
        }

        yield return new WaitForSeconds(4);
        CamZoomToWinner.Instance.StartZooming(players[chosenFirework[chosenWinner] - 1]);
        yield return new WaitForSeconds(4);

        // Add points to the winning player
        switch (players[chosenFirework[chosenWinner] - 1].GetComponent<MainMenuPlayer>().playerNum)
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

        SceneManager.LoadScene("MarkMain");
    }
}
