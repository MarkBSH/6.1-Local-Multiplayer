using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private static MainMenu m_Instance;
    public static MainMenu Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<MainMenu>();
                if (m_Instance == null)
                {
                    GameObject _obj = new()
                    {
                        name = typeof(MainMenu).Name
                    };
                    m_Instance = _obj.AddComponent<MainMenu>();
                }
            }
            return m_Instance;
        }
    }

    [Header("Canvas items")]

    [SerializeField] GameObject[] activeCanv;
    [SerializeField] GameObject[] inactiveCanv;
    [SerializeField] GameObject[] readyCanv;
    [SerializeField] GameObject[] unreadyCanv;

    [Header("Skins")]

    public GameObject[] skinSelector;
    public GameObject[] cosmSelector;
    public int totalSkins;
    public MainMenuPlayer[] mainMenuPlayer;

    int totalPlayers = 0;

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            readyCanv[i].SetActive(false);
            activeCanv[i].SetActive(false);
        }
    }

    void Update()
    {
        if (totalPlayers > 0)
        {
            bool canStartGame = true;

            for (int i = 0; i < totalPlayers; i++)
            {
                if (!mainMenuPlayer[i].isReady)
                {
                    canStartGame = false;
                    readyCanv[i].SetActive(false);
                    unreadyCanv[i].SetActive(true);
                }
                else
                {
                    readyCanv[i].SetActive(true);
                    unreadyCanv[i].SetActive(false);
                }

                if (canStartGame == true && i == totalPlayers - 1)
                {
                    for (int j = 0; j < mainMenuPlayer.Length; j++)
                    {
                        DontDestroyOnLoad(mainMenuPlayer[j].gameObject);
                        CosmeticsSpawner.Instance.chosenCosmetics = new int[mainMenuPlayer.Length];
                        CosmeticsSpawner.Instance.spawningPlayers = totalPlayers;
                        CosmeticsSpawner.Instance.chosenCosmetics[j] = mainMenuPlayer[j].selectedSkin;
                        CosmeticsSpawner.Instance.PlaceCosmetics();
                    }
                    SceneManager.LoadScene("MarkMain");
                }
            }
        }
    }

    public void JoinedGame()
    {
        MainMenuPlayer[] mainMenuPlayerTemp = FindObjectsOfType<MainMenuPlayer>();
        mainMenuPlayer = new MainMenuPlayer[mainMenuPlayerTemp.Length];

        for (int i = 0; i < mainMenuPlayerTemp.Length; i++)
        {
            mainMenuPlayer[i] = mainMenuPlayerTemp[mainMenuPlayerTemp.Length - 1 - i];
        }

        mainMenuPlayer[totalPlayers].gameObject.transform.position = new Vector3(0, -2, 0);
        mainMenuPlayer[totalPlayers].playerNum = totalPlayers;
        activeCanv[totalPlayers].SetActive(true);
        inactiveCanv[totalPlayers].SetActive(false);
        totalPlayers++;
    }

    public void UpdateCosmVisuals()
    {
        for (int i = 0; i < mainMenuPlayer.Length; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int shownSkin = mainMenuPlayer[i].selectedSkin - 1 + j;
                if (shownSkin < 0)
                {
                    shownSkin = totalSkins - 1;
                }
                if (shownSkin > totalSkins - 1)
                {
                    shownSkin = 0;
                }

                for (int k = 0; k < totalSkins; k++)
                {
                    cosmSelector[i * 3 + j].transform.GetChild(k).gameObject.SetActive(false);
                }

                cosmSelector[i * 3 + j].transform.GetChild(shownSkin).gameObject.SetActive(true);
            }

            for (int j = 0; j < totalSkins; j++)
            {
                skinSelector[i].transform.GetChild(0).transform.GetChild(j).gameObject.SetActive(false);
            }

            skinSelector[i].transform.GetChild(0).transform.GetChild(mainMenuPlayer[i].selectedSkin).gameObject.SetActive(true);
        }

        Animator[] animators = GameObject.FindObjectsOfType<Animator>();
        for (int i = 0; i < animators.Length; i++)
        {
            animators[i].SetTrigger("GoToIdle");
        }
    }
}
