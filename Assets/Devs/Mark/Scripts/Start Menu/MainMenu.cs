using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //singleton
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

    [SerializeField] GameObject[] activeCanv; //< img 1 list
    [SerializeField] GameObject[] inactiveCanv; //< img 2 list
    [SerializeField] GameObject[] readyCanv; //< img 3 list
    [SerializeField] GameObject[] unreadyCanv; //< img 4 list

    [Header("Skins")]

    public GameObject[] skinSelector; //< list of player models with all skins on it
    public GameObject[] cosmSelector; //< empty's with all skins on it 3x for every player
    public int totalSkins; //< number of total skins + 1 for an empty
    public MainMenuPlayer[] mainMenuPlayer; //< list of a script on every player

    int totalPlayers = 0; //< number of all players in game

    void Start()
    {
        //automaticly changes some canvases to not be seen
        for (int i = 0; i < 4; i++)
        {
            readyCanv[i].SetActive(false);
            activeCanv[i].SetActive(false);
        }
    }

    void Update()
    {
        //a check to see if any players are in the game
        if (totalPlayers > 0)
        {
            //the bool to see if everyone is ready
            bool canStartGame = true;

            for (int i = 0; i < totalPlayers; i++)
            {
                //check if players are ready + canvas changes
                if (!mainMenuPlayer[i].isReady)
                {
                    //if someone isn't ready the bool goes to false and the game can't start
                    canStartGame = false;
                    readyCanv[i].SetActive(false);
                    unreadyCanv[i].SetActive(true);
                }
                else
                {
                    readyCanv[i].SetActive(true);
                    unreadyCanv[i].SetActive(false);
                }

                //if the bool is on the players are a 'DontDestroyOnLoad' and the cosmetics are applied via the 'CosmeticsSpawner' script
                if (canStartGame == true && i == totalPlayers - 1)
                {
                    for (int j = 0; j < mainMenuPlayer.Length; j++)
                    {
                        DontDestroyOnLoad(mainMenuPlayer[j].gameObject);
                        CosmeticsSpawner.Instance.spawningPlayers = totalPlayers;
                        CosmeticsSpawner.Instance.PlaceCosmetics();
                    }
                    //next scene is loaded
                    SceneManager.LoadScene("MarkMain");

                    Destroy(this);
                }
            }
        }
    }

    //on joining the game
    public void JoinedGame()
    {
        //the players are added to a list, but this list is weird and goes from the newest to the oldest
        MainMenuPlayer[] mainMenuPlayerTemp = FindObjectsOfType<MainMenuPlayer>();
        mainMenuPlayer = new MainMenuPlayer[mainMenuPlayerTemp.Length];
        //player list reversal
        for (int i = 0; i < mainMenuPlayerTemp.Length; i++)
        {
            mainMenuPlayer[i] = mainMenuPlayerTemp[mainMenuPlayerTemp.Length - 1 - i];
        }
        //players are tp'd to under the ground to not see them in te start menu and the number of the newest player is updated
        mainMenuPlayer[totalPlayers].gameObject.transform.position = new Vector3(0, -100, 0);
        mainMenuPlayer[totalPlayers].playerNum = totalPlayers;
        //a ui for the newest player is changed
        activeCanv[totalPlayers].SetActive(true);
        inactiveCanv[totalPlayers].SetActive(false);
        //totalplayers int is updated
        totalPlayers++;
    }

    //function to 'update' the cosmetics shown
    public void UpdateCosmVisuals()
    {
        //for loop for every player
        for (int i = 0; i < mainMenuPlayer.Length; i++)
        {
            //for loop for every skin preview
            for (int j = 0; j < 3; j++)
            {
                //setting the number for which skin preview is shown (the selected skin -1 & +1)
                int shownSkin = mainMenuPlayer[i].selectedSkin - 1 + j;
                if (shownSkin < 0)
                {
                    shownSkin = totalSkins - 1;
                }
                if (shownSkin > totalSkins - 1)
                {
                    shownSkin = 0;
                }

                //disabeling all possible skins and only enabeling the ones chosen with 'shownskin'
                for (int k = 0; k < totalSkins; k++)
                {
                    cosmSelector[i * 3 + j].transform.GetChild(k).gameObject.SetActive(false);
                }

                cosmSelector[i * 3 + j].transform.GetChild(shownSkin).gameObject.SetActive(true);
            }

            //disabeling all possible skins and only enabeling the one chosen with 'selectedskin' in 'mainmenuplayer'
            for (int j = 0; j < totalSkins; j++)
            {
                skinSelector[i].transform.GetChild(0).transform.GetChild(j).gameObject.SetActive(false);
            }

            skinSelector[i].transform.GetChild(0).transform.GetChild(mainMenuPlayer[i].selectedSkin).gameObject.SetActive(true);
        }

        //reseting the animator to have the animation synced
        Animator[] animators = GameObject.FindObjectsOfType<Animator>();
        for (int i = 0; i < animators.Length; i++)
        {
            animators[i].SetTrigger("GoToIdle");
        }
    }
}
