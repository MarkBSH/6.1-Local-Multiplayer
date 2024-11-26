using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windup : MonoBehaviour
{
    public int[] windUpPower = { 0, 0, 0, 0 };
    public bool GameEctive = true;
    public Transform[] Transforms;
    public void windUp(int number)
    {
        windUpPower[number]++;
    }
    public void gameStart()
    {

    }
    public void addSore(int index)
    {
        if (GameEctive == true) 
        {
            windUpPower[index]++;
        }
    }
}
