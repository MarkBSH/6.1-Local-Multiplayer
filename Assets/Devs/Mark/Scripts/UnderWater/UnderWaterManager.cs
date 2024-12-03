using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnderWaterGameManager : MonoBehaviour
{
    private static UnderWaterGameManager m_Instance;
    public static UnderWaterGameManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<UnderWaterGameManager>();
                if (m_Instance == null)
                {
                    GameObject _obj = new();
                    _obj.name = typeof(UnderWaterGameManager).Name;
                    m_Instance = _obj.AddComponent<UnderWaterGameManager>();
                }
            }
            return m_Instance;
        }
    }

    public GameObject[] submarines;
    public List<UnderWaterHealth> underWaterHealths; // List of all cannons' health
    GameObject winner;

    void Start()
    {
        underWaterHealths = new List<UnderWaterHealth>(FindObjectsOfType<UnderWaterHealth>());
        underWaterHealths.Reverse(); // Reverse the order of the obtained canon healths

        int activePlayerCount = CosmeticsSpawner.Instance.spawningPlayers;
        for (int i = underWaterHealths.Count - 1; i >= activePlayerCount; i--)
        {
            Destroy(underWaterHealths[i].gameObject);
            underWaterHealths.RemoveAt(i);
        }
    }

    public IEnumerator OnHealthChanged()
    {
        int aliveCount = 0;

        // Check how many submarines are still alive
        foreach (var submarine in underWaterHealths)
        {
            if (submarine.health > 0)
            {
                aliveCount++;
                winner = submarine.gameObject;
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

    public GameObject GetSubmarineByPlayerNum(int playerNum)
    {
        return submarines[playerNum];
    }
}
