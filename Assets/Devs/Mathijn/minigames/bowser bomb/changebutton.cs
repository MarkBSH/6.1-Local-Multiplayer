using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changebutton : MonoBehaviour
{
    public playerwhere playerwhere;
    public int WhatButtonIsThis;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + " entered the trigger.");
        
        playerwhere.changebutton(WhatButtonIsThis, other.gameObject.GetComponent<MainMenuPlayer>().playerNum);
    }
    private void OnTriggerExit(Collider other)
    {
        playerwhere.changebutton(0, other.gameObject.GetComponent<MainMenuPlayer>().playerNum);
    }
}
