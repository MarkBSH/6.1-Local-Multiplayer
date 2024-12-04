using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnderWaterManager : MonoBehaviour
{
    private static UnderWaterManager m_Instance;
    public static UnderWaterManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<UnderWaterManager>();
            }
            return m_Instance;
        }
    }

    public GameObject[] submarines;
    public List<UnderWaterHealth> underWaterHealths; // List of all cannons' health
    GameObject winner;
    bool hasWon = false;

    void Start()
    {
        int activePlayerCount = CosmeticsSpawner.Instance.spawningPlayers;
        for (int i = underWaterHealths.Count - 1; i >= activePlayerCount; i--)
        {
            Destroy(underWaterHealths[i].gameObject);
            underWaterHealths.RemoveAt(i);
        }
        for (int i = 0; i < underWaterHealths.Count; i++)
        {
            underWaterHealths[i].playerNum = i;
        }
        OnHealthChanged();
    }

    public void OnHealthChanged()
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

        if (aliveCount == 1 && hasWon == false)
        {
            // Award points to the winner
            switch (winner.GetComponent<UnderWaterHealth>().playerNum)
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

            StartCoroutine(EndMoment(winner.transform.position));
        }
    }

    public IEnumerator EndMoment(Vector3 camPos)
    {
        StopAllMovement();

        yield return new WaitForSeconds(1);

        // Zoom camera to the winner
        CamZoomToWinner.Instance.StartZoomingUnderWater(camPos);

        yield return new WaitForSeconds(4);

        // Load the main scene
        SceneManager.LoadScene("MarkMain");
    }

    public void StopAllMovement()
    {
        UnderWaterTunnelMoving[] tunnelMovements = FindObjectsOfType<UnderWaterTunnelMoving>();
        for (int i = 0; i < tunnelMovements.Length; i++)
        {
            tunnelMovements[i].speed = 0;
        }

        UnderWaterMovement[] submarineMovements = FindObjectsOfType<UnderWaterMovement>();
        for (int i = 0; i < submarineMovements.Length; i++)
        {
            submarineMovements[i].speed = 0;
        }
    }
}
