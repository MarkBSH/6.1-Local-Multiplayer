using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChooseGame : MonoBehaviour
{
    public string chosenGame; //< an string of what minigame is chosen

    void OnTriggerEnter(Collider other)
    {
        //if entered a minigame trigger zone the chosen game gets it's name (so every minigame pad needs to have the name of the scene)
        if (other.CompareTag("MinigamePad"))
        {
            chosenGame = other.gameObject.name;
        }
    }

    void OnTriggerExit(Collider other)
    {
        //if you exit the minigame trigger zone the chosen game's name is now an empty
        if (other.CompareTag("MinigamePad"))
        {
            chosenGame = "";
        }
    }
}
