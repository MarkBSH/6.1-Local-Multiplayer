using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager m_Instance;
    public static ScoreManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<ScoreManager>();
                if (m_Instance == null)
                {
                    GameObject _obj = new()
                    {
                        name = typeof(ScoreManager).Name
                    };
                    m_Instance = _obj.AddComponent<ScoreManager>();
                }
            }
            return m_Instance;
        }
    }

    int P1Score;
    TextMeshProUGUI P1Text;
    int P2Score;
    TextMeshProUGUI P2Text;
    int P3Score;
    TextMeshProUGUI P3Text;
    int P4Score;
    TextMeshProUGUI P4Text;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void AddPoints(string winner)
    {
        switch (winner)
        {
            case "P1":
                P1Score++;
                break;
            case "P2":
                P2Score++;
                break;
            case "P3":
                P3Score++;
                break;
            case "P4":
                P4Score++;
                break;
        }
    }

    public void FindAndSetTexts()
    {
        P1Text = GameObject.Find("P1Text").GetComponent<TextMeshProUGUI>();
        P1Text.text = "" + P1Score;
        P2Text = GameObject.Find("P2Text").GetComponent<TextMeshProUGUI>();
        P2Text.text = "" + P2Score;
        P3Text = GameObject.Find("P3Text").GetComponent<TextMeshProUGUI>();
        P3Text.text = "" + P3Score;
        P4Text = GameObject.Find("P4Text").GetComponent<TextMeshProUGUI>();
        P4Text.text = "" + P4Score;
    }
}
