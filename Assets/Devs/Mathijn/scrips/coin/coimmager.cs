using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;
using UnityEngine.Rendering;

public class coimmager : MonoBehaviour
{
    public int[] coins = {0,0,0,0};
    public TMP_Text[] _Texts;
    public void addcoins(int player, int coinss)
    {
        coins[player] += coinss;
        _Texts[player].text = coins[player].ToString();
    }
    public IEnumerator waitandendmylife()
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
