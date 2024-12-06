using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanonGamemanager : MonoBehaviour
{
    private static CanonGamemanager m_Instance;
    public static CanonGamemanager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<CanonGamemanager>();
            }
            return m_Instance;
        }
    }

    public List<CanonHealth> canonHealths; // List of all cannons' health
    GameObject winner; // The winning player's cannon
    bool hasWon = false;

    void Start()
    {
        int activePlayerCount = CosmeticsSpawner.Instance.spawningPlayers;
        for (int i = canonHealths.Count - 1; i >= activePlayerCount; i--)
        {
            Destroy(canonHealths[i].gameObject);
            canonHealths.RemoveAt(i);
        }
        for (int i = 0; i < canonHealths.Count; i++)
        {
            canonHealths[i].playerNum = i;
        }
    }

    public void Update()
    {
        int aliveCount = 0;

        // Check how many cannons are still alive
        foreach (var canon in canonHealths)
        {
            if (canon.health > 0)
            {
                aliveCount++;
                winner = canon.gameObject;
            }
        }

        if (aliveCount == 1 && hasWon == false)
        {
            // Award points to the winner
            switch (winner.GetComponent<CanonHealth>().playerNum)
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

            hasWon = true;

            StartCoroutine(EndMoment());
        }
    }

    IEnumerator EndMoment()
    {
        yield return new WaitForSeconds(1);

        // Zoom camera to the winner
        CamZoomToWinner.Instance.StartZooming(winner);

        yield return new WaitForSeconds(4);

        // Load the main scene
        SceneManager.LoadScene("MarkMain");
    }
}
