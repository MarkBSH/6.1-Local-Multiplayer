using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CosmeticsSpawner : MonoBehaviour
{
    //singleton
    private static CosmeticsSpawner m_Instance;
    public static CosmeticsSpawner Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<CosmeticsSpawner>();
                if (m_Instance == null)
                {
                    GameObject _obj = new()
                    {
                        name = typeof(CosmeticsSpawner).Name
                    };
                    m_Instance = _obj.AddComponent<CosmeticsSpawner>();
                }
            }
            return m_Instance;
        }
    }

    public int spawningPlayers; //< int of total players
    public GameObject[] players; //< list of every player gameobject
    public Material[] playerColors; //< list of the player materials

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void PlaceCosmetics()
    {
        //finds the players and sets the correct player material (player colors)
        players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            players[i].transform.GetChild(0).transform.GetChild(MainMenu.Instance.totalSkins).GetComponent<SkinnedMeshRenderer>().material = playerColors[i];
            //disabeling all possible skins and only enabeling the one chosen with 'selectedskin' in 'mainmenuplayer'
            for (int j = 0; j < MainMenu.Instance.totalSkins; j++)
            {
                players[i].transform.GetChild(0).transform.GetChild(j).gameObject.SetActive(false);
            }
            players[i].transform.GetChild(0).transform.GetChild(players[i].GetComponent<MainMenuPlayer>().selectedSkin).gameObject.SetActive(true);
        }
    }
}
