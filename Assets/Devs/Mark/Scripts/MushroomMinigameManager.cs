using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MushroomMinigameManager : MonoBehaviour
{
    GameObject[] mushroomPlatforms;

    public GameObject[] players;

    [SerializeField] float mushroomSpeed = 50;
    [SerializeField] float goDownCooldown = 5;
    float goDownTimer = -5;

    bool canGiveScore = true;

    void Start()
    {
        mushroomPlatforms = GameObject.FindGameObjectsWithTag("MushroomPlatform");
    }

    void Update()
    {
        if (goDownTimer < goDownCooldown)
        {
            goDownTimer += Time.deltaTime;
        }
        else
        {
            StartCoroutine(MushroomDownEvent());
            goDownTimer = -100;
        }

        players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length == 1 && canGiveScore)
        {
            canGiveScore = false;
            switch (players[0].GetComponent<MainMenuPlayer>().playerNum)
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

            StartCoroutine(EndMoment());
        }
    }

    IEnumerator EndMoment()
    {
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("MarkMain");
    }

    IEnumerator MushroomDownEvent()
    {
        int tempStableMushroom = Random.Range(0, mushroomPlatforms.Length);
        int tempMushroomHeightChecker = Mathf.Abs(tempStableMushroom / 2 + 2);
        if (tempMushroomHeightChecker == tempStableMushroom)
        {
            tempMushroomHeightChecker += 1;
        }

        while (mushroomPlatforms[tempMushroomHeightChecker].transform.position.y > -5)
        {
            for (int i = 0; i < mushroomPlatforms.Length; i++)
            {
                if (tempStableMushroom != i)
                {
                    mushroomPlatforms[i].transform.position += Vector3.down * mushroomSpeed * Time.deltaTime;
                }
                yield return new WaitForSeconds(0);
            }
        }

        while (mushroomPlatforms[tempMushroomHeightChecker].transform.position.y < 0)
        {
            for (int i = 0; i < mushroomPlatforms.Length; i++)
            {
                if (tempStableMushroom != i)
                {
                    mushroomPlatforms[i].transform.position += Vector3.up * mushroomSpeed * Time.deltaTime;
                }
                yield return new WaitForSeconds(0);
            }
        }

        goDownTimer = 0;
    }
}
