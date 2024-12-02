using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coimmager : MonoBehaviour
{
    public int[] coins = {0,0,0,0};
    public void addcoins(int player, int coinss)
    {
        coins[player] += coinss;
    }
}
