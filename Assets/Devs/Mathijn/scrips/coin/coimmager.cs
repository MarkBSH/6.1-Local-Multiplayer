using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class coimmager : MonoBehaviour
{
    public int[] coins = {0,0,0,0};
    public void addcoins(int player, int coinss)
    {
        coins[player] += coinss;
    }
    private IEnumerator waitandendmylife()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < coins.Length; i++)
        {
            if (coins[i] == coins.Max())
            {
                switch (i)
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

        SceneManager.LoadScene("MarkMain");

    }
}
