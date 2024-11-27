using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    //singleton
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

    int P1Score = 0; //< player 1 score
    TextMeshProUGUI P1Text; //< player 1 score text
    int P2Score = 0; //< player 2 score
    TextMeshProUGUI P2Text; //< player 2 score text
    int P3Score = 0; //< player 3 score
    TextMeshProUGUI P3Text; //< player 3 score text
    int P4Score = 0; //< player 4 score
    TextMeshProUGUI P4Text; //< player 4 score text

    void Start()
    {
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MarkMain")
        {
            FindAndSetTexts();
        }
    }


    //adds points to a player depending on who wins
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

    //function to show the scores on screen
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
