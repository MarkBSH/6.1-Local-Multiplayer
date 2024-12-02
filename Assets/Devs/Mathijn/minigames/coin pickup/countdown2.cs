using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Countdown3 : MonoBehaviour
{
    public int timer;
    public int timerstart;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private TextMeshProUGUI _textMeshPro2;
    [SerializeField] private Image countdown;
    [SerializeField] private Sprite redbackgroundthing;
    [SerializeField] private Animator Animator;
    [SerializeField] private Animator Animatorfinish;
    [SerializeField] private coimmager coimmager;
    GameObject[] players;
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < CosmeticsSpawner.Instance.players.Length; i++)
        {
            players[i].GetComponent<coinspickup>().enabled = true;
        }
        StartCoroutine(StartCountdown2());
    }
    IEnumerator StartCountdown2() 
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
        coimmager.StartCoroutine(StartCountdown());
    }
}