using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveGameBox : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(QuitGame());
        }
    }

    IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(1);

        Debug.Log("Quit");

        Application.Quit();
    }
}
