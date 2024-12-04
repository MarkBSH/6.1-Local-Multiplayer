using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameChooser : MonoBehaviour
{
    private static MinigameChooser m_Instance;
    public static MinigameChooser Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<MinigameChooser>();
            }
            return m_Instance;
        }
    }

    public PlayerChooseGame[] games; // Array of PlayerChooseGame scripts
    string[] chosenGames; // Array to store chosen games
    GameObject countdownText; // UI element for countdown
    GameObject choosingPanel; // UI panel displayed during choosing
    [SerializeField] Animator chooseAnimation; // Animator for selection animation
    bool canStartCooldown = true; // Control variable for cooldown
    Coroutine co; // Reference to the running coroutine
    bool hasSaved = false; // Indicates if the game choice has been saved

    void Awake()
    {
        // Initialize UI elements
        countdownText = GameObject.Find("CountdownText");
        countdownText.SetActive(false);
        choosingPanel = GameObject.Find("ChoosingPanel");
        choosingPanel.SetActive(false);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Set up players for the minigame selection
        games = FindObjectsOfType<PlayerChooseGame>();
        chosenGames = new string[games.Length];
    }

    void Update()
    {
        // Update chosen games
        for (int i = 0; i < games.Length; i++)
        {
            chosenGames[i] = games[i].chosenGame;
        }

        // Check if all players have chosen a game
        for (int i = 0; i < games.Length; i++)
        {
            if (chosenGames[i] == "")
            {
                countdownText.SetActive(false);
                canStartCooldown = true;
                if (co != null && !hasSaved)
                {
                    StopCoroutine(co);
                }
                break;
            }
            if (i == games.Length - 1)
            {
                if (canStartCooldown)
                {
                    co = StartCoroutine(StartCountdown());
                }
            }
        }
    }

    IEnumerator StartCountdown()
    {
        canStartCooldown = false;
        countdownText.SetActive(true);
        // Countdown loop
        for (int i = 5; i >= 0; i--)
        {
            countdownText.GetComponent<TextMeshProUGUI>().text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        StartCoroutine(CyclePlayers());
    }

    IEnumerator CyclePlayers()
    {
        hasSaved = true;
        countdownText.SetActive(false);
        // Randomly select a player's chosen game
        int tempChosenPlayer = Random.Range(0, games.Length);
        string confirmedGame = chosenGames[tempChosenPlayer];
        string tempChosenAnimation = $"Player {tempChosenPlayer + 1}";
        choosingPanel.SetActive(true);
        chooseAnimation.SetTrigger(tempChosenAnimation);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(confirmedGame);
    }
}
