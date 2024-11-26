using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameChooser : MonoBehaviour
{
    //singleton
    private static MinigameChooser m_Instance;
    public static MinigameChooser Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<MinigameChooser>();
                if (m_Instance == null)
                {
                    GameObject _obj = new()
                    {
                        name = typeof(MinigameChooser).Name
                    };
                    m_Instance = _obj.AddComponent<MinigameChooser>();
                }
            }
            return m_Instance;
        }
    }

    public PlayerChooseGame[] games; //< list of a script on every player
    string[] chosenGames; //< list of the chosen games by players
    GameObject countdownText; //< gameobject with the text for the countdown
    GameObject choosingPanel; //< gameobject with the panels for choosing the game
    [SerializeField] Animator chooseAnimation; //< an animator for the choose animation
    bool canStartCooldown = true; //< a bool to not interupt the coroutine
    Coroutine co; //< to be able to stop the coroutine
    bool hasSaved = false;

    void Awake()
    {
        //finding and disabeling the UI for later
        countdownText = GameObject.Find("CountdownText");
        countdownText.SetActive(false);
        choosingPanel = GameObject.Find("ChoosingPanel");
        choosingPanel.SetActive(false);
    }

    //function to clear the chosen games from last round
    public void PlayerSetup()
    {
        games = FindObjectsOfType<PlayerChooseGame>();
        chosenGames = new string[games.Length];
    }

    void Update()
    {
        //for loop to get all chosen games
        for (int i = 0; i < games.Length; i++)
        {
            chosenGames[i] = games[i].chosenGame;
        }
        //for loop to check if everyone has chosen a game and then stopping/starting the countdown coroutine
        for (int i = 0; i < games.Length; i++)
        {
            if (chosenGames[i] == "")
            {
                countdownText.SetActive(false);
                canStartCooldown = true;
                if (co != null && hasSaved == false)
                {
                    StopCoroutine(co);
                }
                break;
            }
            if (i == games.Length - 1)
            {
                if (canStartCooldown == true)
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
        //countdown for loop
        for (int i = 5; i >= 0; i--)
        {
            countdownText.GetComponent<TextMeshProUGUI>().text = i + "";
            yield return new WaitForSeconds(1);
        }

        StartCoroutine(CyclePlayers());
    }

    IEnumerator CyclePlayers()
    {
        hasSaved = true;
        countdownText.SetActive(false);
        //confirms the games so if someone goes off the button it's still these mingames
        string[] confirmedGames = chosenGames;
        //randomly choosing the minigame
        int tempChosenPlayer = Random.Range(0, games.Length);
        //showing an animation for who wins
        string tempChosenAnimation = "Player " + (tempChosenPlayer + 1);
        choosingPanel.SetActive(true);
        chooseAnimation.SetTrigger(tempChosenAnimation);
        yield return new WaitForSeconds(5);
        //loading the scene of the chosen minigame
        SceneManager.LoadScene(confirmedGames[tempChosenPlayer]);
    }
}
