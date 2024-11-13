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

    public PlayerChooseGame[] games;
    string[] chosenGames;
    GameObject countdownText;
    GameObject choosingPanel;
    [SerializeField] Animator chooseAnimation;
    bool canStartCooldown = true;
    Coroutine co;

    void Awake()
    {
        countdownText = GameObject.Find("CountdownText");
        countdownText.SetActive(false);
        choosingPanel = GameObject.Find("ChoosingPanel");
        choosingPanel.SetActive(false);
    }

    public void PlayerSetup()
    {
        games = FindObjectsOfType<PlayerChooseGame>();
        chosenGames = new string[games.Length];
    }

    void Update()
    {
        for (int i = 0; i < games.Length; i++)
        {
            chosenGames[i] = games[i].chosenGame;
        }
        for (int i = 0; i < games.Length; i++)
        {
            if (chosenGames[i] == "")
            {
                countdownText.SetActive(false);
                canStartCooldown = true;
                StopCoroutine(co);
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

        for (int i = 5; i >= 0; i--)
        {
            countdownText.GetComponent<TextMeshProUGUI>().text = i + "";
            yield return new WaitForSeconds(1);
        }

        StartCoroutine(CyclePlayers());
    }

    IEnumerator CyclePlayers()
    {
        countdownText.SetActive(false);
        string[] confirmedGames = chosenGames;
        int tempChosenPlayer = Random.Range(1, games.Length);
        string tempChosenAnimation = "Player " + tempChosenPlayer;
        choosingPanel.SetActive(true);
        chooseAnimation.SetTrigger(tempChosenAnimation);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(confirmedGames[tempChosenPlayer]);
    }
}
