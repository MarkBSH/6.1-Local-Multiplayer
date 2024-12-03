using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveGameBox : MonoBehaviour
{
    // Called when another collider enters this trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(QuitGame());
        }
    }

    // Coroutine to quit the game after a delay
    IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Quit");
        Application.Quit();
    }
}
