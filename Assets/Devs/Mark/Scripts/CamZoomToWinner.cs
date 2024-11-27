using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoomToWinner : MonoBehaviour
{
    //singleton
    private static CamZoomToWinner m_Instance;
    public static CamZoomToWinner Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<CamZoomToWinner>();
                if (m_Instance == null)
                {
                    GameObject _obj = new()
                    {
                        name = typeof(CamZoomToWinner).Name
                    };
                    m_Instance = _obj.AddComponent<CamZoomToWinner>();
                }
            }
            return m_Instance;
        }
    }

    [SerializeField] Vector3 startLocation; //< resets the camera to the startlocation
    GameObject winningPlayer; //< takes the location of the winning player
    bool canZoom = false; //< check for if the cam can zoom in
    float timer = 0; //< slerp timer

    void Start()
    {
        //restes the location of the cam
        transform.position = startLocation;
    }

    void Update()
    {
        //slerp for zooming in to the winning player
        if (canZoom)
        {
            transform.position = Vector3.Slerp(startLocation, new Vector3(winningPlayer.transform.position.x, winningPlayer.transform.position.y + 5, winningPlayer.transform.position.z - 5), timer);
            timer += Time.deltaTime / 2;
        }
    }

    //finds the player and starts the zoom in
    public void StartZooming(GameObject player)
    {
        canZoom = true;
        winningPlayer = player;
    }
}
