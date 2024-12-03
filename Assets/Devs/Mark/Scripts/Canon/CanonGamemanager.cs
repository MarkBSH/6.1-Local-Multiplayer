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
                GameObject _obj = new();
                _obj.name = typeof(CanonGamemanager).Name;
                m_Instance = _obj.AddComponent<CanonGamemanager>();
            }
            return m_Instance;
        }
    }

    public List<CanonHealth> canonHealths; // List of all cannons' health
    GameObject winner; // The winning player's cannon

    void Start()
    {
        canonHealths = new List<CanonHealth>(FindObjectsOfType<CanonHealth>());
        canonHealths.Reverse(); // Reverse the order of the obtained canon healths

        int activePlayerCount = CosmeticsSpawner.Instance.spawningPlayers;
        for (int i = canonHealths.Count - 1; i >= activePlayerCount; i--)
        {
            Destroy(canonHealths[i].gameObject);
            canonHealths.RemoveAt(i);
        }
    }

    public IEnumerator OnHealthChanged()
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

        if (aliveCount == 1)
        {
            // Award points to the winner
            switch (winner.GetComponent<MainMenuPlayer>().playerNum)
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
            yield return new WaitForSeconds(1);

            // Zoom camera to the winner
            CamZoomToWinner.Instance.StartZooming(winner);

            yield return new WaitForSeconds(4);

            // Load the main scene
            SceneManager.LoadScene("MarkMain");
        }
    }
}
