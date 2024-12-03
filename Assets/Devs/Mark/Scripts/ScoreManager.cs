using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    // Singleton instance
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
                    GameObject _obj = new();
                    _obj.name = typeof(ScoreManager).Name;
                    m_Instance = _obj.AddComponent<ScoreManager>();
                }
            }
            return m_Instance;
        }
    }

    // Player scores and associated UI texts
    int P1Score = 0;
    TextMeshProUGUI P1Text;
    int P2Score = 0;
    TextMeshProUGUI P2Text;
    int P3Score = 0;
    TextMeshProUGUI P3Text;
    int P4Score = 0;
    TextMeshProUGUI P4Text;

    void Start()
    {
        // Prevent this object from being destroyed and subscribe to scene loaded event
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Update score texts when the main scene is loaded
        if (scene.name == "MarkMain")
        {
            FindAndSetTexts();
        }
    }

    // Add points to a player's score based on the winner
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

    // Find and set the score texts on the UI
    public void FindAndSetTexts()
    {
        P1Text = GameObject.Find("P1Text").GetComponent<TextMeshProUGUI>();
        P1Text.text = P1Score.ToString();
        P2Text = GameObject.Find("P2Text").GetComponent<TextMeshProUGUI>();
        P2Text.text = P2Score.ToString();
        P3Text = GameObject.Find("P3Text").GetComponent<TextMeshProUGUI>();
        P3Text.text = P3Score.ToString();
        P4Text = GameObject.Find("P4Text").GetComponent<TextMeshProUGUI>();
        P4Text.text = P4Score.ToString();
    }
}
