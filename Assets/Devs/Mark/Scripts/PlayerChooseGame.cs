using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChooseGame : MonoBehaviour
{
    public string chosenGame;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MinigamePad"))
        {
            chosenGame = other.gameObject.name;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MinigamePad"))
        {
            chosenGame = "";
        }
    }
}
