using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CamZoomToWinner : MonoBehaviour
{
    private static CamZoomToWinner m_Instance;
    public static CamZoomToWinner Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<CamZoomToWinner>();
            }
            return m_Instance;
        }
    }

    [SerializeField] Vector3 startLocation; // Starting position of the camera
    GameObject winningPlayer; // The winning player's game object
    Vector3 winningPos; // The winning player's game object
    bool canZoom = false; // Flag to control zoom action
    bool canZoomUnderWater = false; // Flag to control zoom action
    bool canTurn = false; // Flag to control rotation
    float timer = 0; // Timer for interpolation

    void Update()
    {
        if (canZoom)
        {
            // Smoothly move the camera towards the winner
            transform.position = Vector3.Slerp(
                startLocation,
                new Vector3(
                    winningPlayer.transform.position.x,
                    winningPlayer.transform.position.y + 5,
                    winningPlayer.transform.position.z - 5
                ),
                timer
            );
            timer += Time.deltaTime / 2;
            if (timer > 1)
            {
                timer = 0;
                canZoom = false;
            }
        }

        if (canZoomUnderWater)
        {
            // Smoothly move the camera towards the winner
            transform.position = Vector3.Slerp(
                startLocation,
                new Vector3(
                    winningPos.x,
                    winningPos.y,
                    winningPos.z - 5
                ),
                timer
            );
            timer += Time.deltaTime / 2;
            if (timer > 1)
            {
                timer = 0;
                canZoomUnderWater = false;
            }
        }

        if (canTurn)
        {
            // Smoothly rotate the camera
            transform.rotation = Quaternion.Euler(
                Vector3.Slerp(new Vector3(40, 0, 0), new Vector3(30, 0, 0), timer)
            );
            timer += Time.deltaTime / 2;
            if (timer > 1)
            {
                timer = 0;
                canTurn = false;
            }
        }
    }

    public void StartZooming(GameObject player)
    {
        canZoom = true;
        winningPlayer = player;
        startLocation = transform.position;
    }

    public void StartZoomingUnderWater(Vector3 camPos)
    {
        canZoomUnderWater = true;
        winningPos = camPos;
        startLocation = transform.position;
    }

    public void CamLookUp()
    {
        canTurn = true;
    }
}
