using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CosmeticsSpawner : MonoBehaviour
{
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

    public int spawningPlayers;
    public GameObject[] players;
    public int[] chosenCosmetics;
    public Material[] playerColors;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void PlaceCosmetics()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            players[i].transform.GetChild(0).transform.GetChild(MainMenu.Instance.totalSkins).GetComponent<SkinnedMeshRenderer>().material = playerColors[i];
            for (int j = 0; j < MainMenu.Instance.totalSkins; j++)
            {
                players[i].transform.GetChild(0).transform.GetChild(j).gameObject.SetActive(false);
            }
            players[i].transform.GetChild(0).transform.GetChild(players[i].GetComponent<MainMenuPlayer>().selectedSkin).gameObject.SetActive(true);
        }
    }
}
