using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class EndSceneCanvas : MonoBehaviour
{
    public GameObject[] playerCanvases;
    public TextMeshProUGUI[] playerScores;
    public int sameScores;
    public int[] canvasL;
    public int[] canvasR;

    void Start()
    {
        for (int i = 0; i < 4;)
        {
            sameScores = 0;
            List<int> tempScores = new(ScoreManager.Instance.scores);
            for (int j = 0; j < i; j++)
            {
                tempScores.Remove(tempScores.Max());
            }

            for (int j = 0; j < tempScores.Count; j++)
            {
                if (tempScores[j] == tempScores.Max())
                {
                    sameScores++;
                    i++;
                }
            }
            for (int j = 0; j < sameScores; j++)
            {
                Debug.Log(tempScores.Max());
                Debug.Log(ScoreManager.Instance.scores.IndexOf(tempScores.Max()));
                Debug.Log(ScoreManager.Instance.scores.IndexOf(tempScores.Max()) + j);
                int currentIndex = ScoreManager.Instance.scores.IndexOf(tempScores.Max()) + j;
                Debug.Log(currentIndex);
                playerCanvases[currentIndex].GetComponent<RectTransform>().offsetMin = new Vector2(canvasL[i - sameScores + j], playerCanvases[currentIndex].GetComponent<RectTransform>().offsetMin.y);
                playerCanvases[currentIndex].GetComponent<RectTransform>().offsetMax = new Vector2(-canvasR[i - sameScores + j], playerCanvases[currentIndex].GetComponent<RectTransform>().offsetMax.y);

                playerScores[i - sameScores + j].text = tempScores.Max().ToString();
            }
        }
    }
}
