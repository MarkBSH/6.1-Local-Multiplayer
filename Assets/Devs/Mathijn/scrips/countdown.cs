using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public int timer;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private Image countdown;
    [SerializeField] private Sprite redbackgroundthing;
    [SerializeField] private Animator Animator;
    [SerializeField] private SpawnLavaMonster SpawnLavaMonster;
    void Start()
    {
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
        SpawnLavaMonster.stopspawn();
        Animator.SetTrigger("effect");
    }
}