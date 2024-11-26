using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MarkCountdown : MonoBehaviour
{
    int count = 100;
    [SerializeField] TextMeshProUGUI countText;
    [SerializeField] Image countdown;
    [SerializeField] Sprite redbackgroundthing;
    [SerializeField] Animator Animator;
    [SerializeField] Animator Animatorfinish;

    void Update()
    {
        countText.text = count.ToString();

        if (count < 10)
        {
            Animator.SetTrigger("effect");
            countdown.sprite = redbackgroundthing;
        }
        if (count < 0)
        {
            Animatorfinish.SetTrigger("hide");
            Animator.SetTrigger("effect");
            Animatorfinish.SetTrigger("finish");
        }
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);
        count--;

        if (count == 0)
        {
            StartCoroutine(Countdown());
        }
    }
}
