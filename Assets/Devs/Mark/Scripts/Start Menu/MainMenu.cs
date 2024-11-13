using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CosmeticStats
{
    public Mesh mesh;
    public Material material;
}

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

    [Header("Cosmetics list")]
    [SerializeField] List<CosmeticStats> cosmeticsList = new();

    [Header("Canvas items")]

    [SerializeField] GameObject[] activeCanv;
    [SerializeField] GameObject[] inactiveCanv;
    [SerializeField] GameObject[] readyCanv;
    [SerializeField] GameObject[] unreadyCanv;

    [Header("Skins")]

    public GameObject[] skinSelector;
    public GameObject[] cosmSelector;
    MainMenuPlayer[] mainMenuPlayer;

    int totalPlayers = 0;

    void Awake()
    {
        skinSelector = GameObject.FindGameObjectsWithTag("PlayerSkinSelector");
        cosmSelector = GameObject.FindGameObjectsWithTag("CosmSkinSelector");
    }
    
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
                    //start game
                    Debug.Log("start");
                }
            }
        }
    }

    public void JoinedGame()
    {
        mainMenuPlayer = FindObjectsOfType<MainMenuPlayer>();
        mainMenuPlayer[totalPlayers].playerNum = totalPlayers;
        activeCanv[totalPlayers].SetActive(true);
        inactiveCanv[totalPlayers].SetActive(false);
        totalPlayers++;
    }
}
