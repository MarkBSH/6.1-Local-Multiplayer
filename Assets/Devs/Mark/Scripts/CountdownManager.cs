using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownManager : MonoBehaviour
{
    int count = 100; // Timer until the game is over
    [SerializeField] TextMeshProUGUI countText; // UI text for the timer
    [SerializeField] Image countdownBox; // UI image for the countdown box
    [SerializeField] Sprite redCountdownBox; // Sprite when the timer is low
    [SerializeField] Animator countdownBoxAnim; // Animator for countdown effects
    [SerializeField] Animator animatorFinish; // Animator for finish effects

    void Start()
    {
        StartCoroutine(Countdown());
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Restarts the countdown when a new scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(Countdown());
    }

    // Handles the countdown timer
    IEnumerator Countdown()
    {
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
