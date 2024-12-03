using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChooseGame : MonoBehaviour
{
    public string chosenGame; // Name of the selected minigame

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MinigamePad"))
        {
            chosenGame = other.gameObject.name; // Store the minigame name
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MinigamePad"))
        {
            chosenGame = ""; // Reset the chosen game
        }
    }
}
