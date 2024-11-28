using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownManager : MonoBehaviour
{
    int count = 100; //< timer till game is over
    [SerializeField] TextMeshProUGUI countText; //< text for the timer
    [SerializeField] Image countdownBox; //< box for sprite change
    [SerializeField] Sprite redCountdownBox; //< sprite changer
    [SerializeField] Animator countdownBoxAnim; //< animator for countdown effect
    [SerializeField] Animator animatorFinish; //< animator for finnish effect

    //coroutine starter

    void Start()
    {
        StartCoroutine(Countdown());
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        //countdown every second and updating the text
        yield return new WaitForSeconds(1);
        count--;

        countText.text = count.ToString();

        if (count < 10)
        {
            countdownBoxAnim.SetTrigger("effect");
            countdownBox.sprite = redCountdownBox;
        }
        if (count <= 0)
        {
            animatorFinish.SetTrigger("hide");
            countdownBoxAnim.SetTrigger("effect");
            animatorFinish.SetTrigger("finish");
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("MarkMain");
        }

        if (count != 0)
        {
            StartCoroutine(Countdown());
        }
    }
}
