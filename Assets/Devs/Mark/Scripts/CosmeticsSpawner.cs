using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChosenCosmetics
{
    public Mesh mesh;
    public Material material;
}

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
    public ChosenCosmetics[] chosenCosmeticsList;
    public GameObject[] players;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void PlaceCosmetics()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            players[i].transform.GetChild(0).transform.GetChild(0).GetComponent<MeshFilter>().mesh = chosenCosmeticsList[i].mesh;
            players[i].transform.GetChild(0).transform.GetChild(0).GetComponent<MeshRenderer>().material = chosenCosmeticsList[i].material;
        }
    }
}
