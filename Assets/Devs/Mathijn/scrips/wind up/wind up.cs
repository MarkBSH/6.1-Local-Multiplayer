using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Windup : MonoBehaviour
{
    public int[] windUpPower = { 1, 1, 1, 1 };
    public void windUp(int number)
    {
        windUpPower[number]++;
    }
    public void gameStart()
    {

    }
}
