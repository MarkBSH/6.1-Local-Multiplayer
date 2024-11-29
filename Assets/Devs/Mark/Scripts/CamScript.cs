using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    float LPos;
    float RPos;
    float UPos;
    float DPos;
    GameObject camObj;
    Vector3 camPos;

    void Start()
    {
        camObj = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        LPos = -10000;
        RPos = 10000;
        UPos = -10000;
        DPos = 10000;

        for (int i = 0; i < CosmeticsSpawner.Instance.players.Length; i++)
        {
            if (CosmeticsSpawner.Instance.players[i].transform.position.x > LPos)
            {
                LPos = CosmeticsSpawner.Instance.players[i].transform.position.x;
            }
            if (CosmeticsSpawner.Instance.players[i].transform.position.x < RPos)
            {
                RPos = CosmeticsSpawner.Instance.players[i].transform.position.x;
            }
            if (CosmeticsSpawner.Instance.players[i].transform.position.z > UPos)
            {
                UPos = CosmeticsSpawner.Instance.players[i].transform.position.z;
            }
            if (CosmeticsSpawner.Instance.players[i].transform.position.z < DPos)
            {
                DPos = CosmeticsSpawner.Instance.players[i].transform.position.z;
            }
        }

        camPos = new Vector3((RPos + LPos) / 2, 0, (UPos + DPos) / 2);
        transform.position = camPos;
        camObj.transform.LookAt(camPos);
    }
}
