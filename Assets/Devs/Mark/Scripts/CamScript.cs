using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    float LPos; // Leftmost player position
    float RPos; // Rightmost player position
    float UPos; // Uppermost player position
    float DPos; // Downmost player position
    GameObject camObj; // Camera GameObject
    Vector3 camPos; // Camera position

    void Start()
    {
        camObj = transform.GetChild(0).gameObject; // Get the child camera object
    }

    void Update()
    {
        // Initialize positions with extreme values to find min and max
        LPos = -10000;
        RPos = 10000;
        UPos = -10000;
        DPos = 10000;

        // Determine the bounds based on player positions
        for (int i = 0; i < CosmeticsSpawner.Instance.players.Length; i++)
        {
            // Update leftmost and rightmost positions
            if (CosmeticsSpawner.Instance.players[i].transform.position.x > LPos)
            {
                LPos = CosmeticsSpawner.Instance.players[i].transform.position.x;
            }
            if (CosmeticsSpawner.Instance.players[i].transform.position.x < RPos)
            {
                RPos = CosmeticsSpawner.Instance.players[i].transform.position.x;
            }
            // Update uppermost and downmost positions
            if (CosmeticsSpawner.Instance.players[i].transform.position.z > UPos)
            {
                UPos = CosmeticsSpawner.Instance.players[i].transform.position.z;
            }
            if (CosmeticsSpawner.Instance.players[i].transform.position.z < DPos)
            {
                DPos = CosmeticsSpawner.Instance.players[i].transform.position.z;
            }
        }

        // Calculate the center position between players
        camPos = new Vector3((RPos + LPos) / 2, 0, (UPos + DPos) / 2);
        transform.position = camPos; // Move the camera to the center
        camObj.transform.LookAt(camPos); // Make the camera look at the center
    }
}
