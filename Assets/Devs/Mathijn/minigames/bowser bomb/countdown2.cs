using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Countdown4 : MonoBehaviour
{
    public int timer;
    public int timerstart;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private TextMeshProUGUI _textMeshPro2;
    [SerializeField] private Image countdown;
    [SerializeField] private Sprite redbackgroundthing;
    [SerializeField] private Sprite notredbackgroundthing;
    [SerializeField] private Animator Animator;
    [SerializeField] private Animator Animatorfinish;
    [SerializeField] private playerwhere playerwhere;
    GameObject[] players;
    void Start()
    {
        
    }
    public IEnumerator StartCountdown2() 
    {
        while (timerstart > 0) 
        {
            timerstart--;
            yield return new WaitForSeconds(1f);
            _textMeshPro2.text = timerstart.ToString();
        }
        _textMeshPro2.text = "";
        StartCoroutine(StartCountdown());
    }
    IEnumerator StartCountdown()
    {
        countdown.sprite = notredbackgroundthing;
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);
            timer--;
            _textMeshPro.text = timer.ToString();

            if (timer < 6)
            {
                Animator.SetTrigger("effect");
            }
            if (timer < 6)
            {
                countdown.sprite = redbackgroundthing;
            }
        }
        _textMeshPro.text = "0";
        Animator.SetTrigger("effect");
        playerwhere.pressbutton();
    }
}