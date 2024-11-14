using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public List<CosmeticStats> cosmeticsList = new();

    [Header("Canvas items")]

    [SerializeField] GameObject[] activeCanv;
    [SerializeField] GameObject[] inactiveCanv;
    [SerializeField] GameObject[] readyCanv;
    [SerializeField] GameObject[] unreadyCanv;

    [Header("Skins")]

    public GameObject[] skinSelector;
    public GameObject[] cosmSelector;
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
                        CosmeticsSpawner.Instance.spawningPlayers = totalPlayers;
                        CosmeticsSpawner.Instance.chosenCosmeticsList[j].mesh = cosmeticsList[mainMenuPlayer[j].SelectedSkin].mesh;
                        CosmeticsSpawner.Instance.chosenCosmeticsList[j].material = cosmeticsList[mainMenuPlayer[j].SelectedSkin].material;
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
                int shownSkin = mainMenuPlayer[i].SelectedSkin - 1 + j;
                if (shownSkin < 0)
                {
                    shownSkin = cosmeticsList.Count - 1;
                }
                if (shownSkin > cosmeticsList.Count - 1)
                {
                    shownSkin = 0;
                }
                cosmSelector[i * 3 + j].transform.GetChild(0).GetComponent<MeshFilter>().mesh = cosmeticsList[shownSkin].mesh;
                cosmSelector[i * 3 + j].transform.GetChild(0).GetComponent<MeshRenderer>().material = cosmeticsList[shownSkin].material;
            }
            skinSelector[i].transform.GetChild(0).transform.GetChild(0).GetComponent<MeshFilter>().mesh = cosmeticsList[mainMenuPlayer[i].SelectedSkin].mesh;
            skinSelector[i].transform.GetChild(0).transform.GetChild(0).GetComponent<MeshRenderer>().material = cosmeticsList[mainMenuPlayer[i].SelectedSkin].material;
        }
    }
}
