using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireworkMinigameManager : MonoBehaviour
{
    //singleton
    private static FireworkMinigameManager m_Instance;
    public static FireworkMinigameManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<FireworkMinigameManager>();
                if (m_Instance == null)
                {
                    GameObject _obj = new()
                    {
                        name = typeof(FireworkMinigameManager).Name
                    };
                    m_Instance = _obj.AddComponent<FireworkMinigameManager>();
                }
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

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        chosenFirework = new int[4];
        hasEnded = false;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
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

    IEnumerator EndGame()
    {
        CamZoomToWinner.Instance.CamLookUp();

        yield return new WaitForSeconds(1f);

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
