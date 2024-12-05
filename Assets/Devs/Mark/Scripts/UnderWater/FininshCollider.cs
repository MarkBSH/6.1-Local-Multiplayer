using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FininshCollider : MonoBehaviour
{
    public bool hasCollided = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && hasCollided == false)
        {
            hasCollided = true;
            StartCoroutine(UnderWaterManager.Instance.EndMoment(new Vector3(0, 0, -5)));
            UnderWaterHealth[] underWaterHealth = FindObjectsOfType<UnderWaterHealth>();
            for (int i = 0; i < underWaterHealth.Length; i++)
            {
                switch (underWaterHealth[i].playerNum)
                {
                    case 0:
                        ScoreManager.Instance.AddPoints("P1");
                        break;
                    case 1:
                        ScoreManager.Instance.AddPoints("P2");
                        break;
                    case 2:
                        ScoreManager.Instance.AddPoints("P3");
                        break;
                    case 3:
                        ScoreManager.Instance.AddPoints("P4");
                        break;
                }
            }
        }
    }
}
