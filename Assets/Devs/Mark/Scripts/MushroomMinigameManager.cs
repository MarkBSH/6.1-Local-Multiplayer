using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMinigameManager : MonoBehaviour
{
    GameObject[] mushroomPlatforms;

    [SerializeField] float mushroomSpeed = 50;
    [SerializeField] float goDownCooldown = 5;
    float goDownTimer = -5;


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
