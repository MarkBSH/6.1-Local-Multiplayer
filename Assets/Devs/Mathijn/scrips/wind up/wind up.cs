using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Windup : MonoBehaviour
{
    public int[] windUpPower = { 0, 0, 0, 0 };
    public bool GameActive = true;
    public Transform[] Transforms;
    public float speed = 1f;
    [SerializeField] private Animator Animatorfinish;
    [SerializeField] private Transform camaratransform;
    public bool anamionsend = false;

    public void windUp(int number)
    {
        if (number >= 0 && number < windUpPower.Length)
        {
            windUpPower[number]++;
        }
    }

    public void gameStart()
    {
        StartCoroutine(MoveObjectsAndCameraAtOnce());
    }

    private IEnumerator MoveObjectsAndCameraAtOnce()
    {
        List<Coroutine> coroutines = new List<Coroutine>();

        for (int i = 0; i < Transforms.Length; i++)
        {
            if (Transforms[i] != null)
            {
                coroutines.Add(StartCoroutine(MoveObjectAndCameraOverTime(i)));
            }
        }
        foreach (Coroutine c in coroutines)
        {
            yield return c;
        }
        Animatorfinish.SetTrigger("finish");
        StartCoroutine(waitandendmylife());

    }
    private IEnumerator waitandendmylife()
    {
        yield return new WaitForSeconds(1.5f);
        ScoreManager.Instance.AddPoints("P3");
        SceneManager.LoadScene("MarkMain");

    }
    private IEnumerator MoveObjectAndCameraOverTime(int i) 
    {
        float totalMoveDistance = windUpPower[i] * speed;
        float moveTime = totalMoveDistance / speed;
        moveTime = moveTime / 4;
        float elapsedTime = 0f;
        Vector3 initialPosition = Transforms[i].position;
        Vector3 initialCameraPosition = camaratransform.position;
        while (elapsedTime < moveTime)
        {
            float moveAmount = Mathf.Lerp(0, totalMoveDistance, elapsedTime / moveTime);
            Transforms[i].position = initialPosition + Vector3.right * moveAmount;
            camaratransform.position = initialCameraPosition + Vector3.right * moveAmount;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Transforms[i].position = initialPosition + Vector3.right * totalMoveDistance;
        camaratransform.position = initialCameraPosition + Vector3.right * totalMoveDistance;
    }

    public void addScore(int index)
    {
        if (GameActive && index >= 0 && index < windUpPower.Length)
        {
            windUpPower[index]++;
        }
    }
}
