using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MushroomMinigameManager : MonoBehaviour
{
    GameObject[] mushroomPlatforms; //< list of the mushroom platforms
    public GameObject[] players; //< list of players

    [SerializeField] float mushroomSpeed = 10; //< the speed of how fast the mushrooms go down
    [SerializeField] float goDownCooldown = 3; //< the 'cooldown' for the mushrooms to go down
    float goDownTimer = -3; //< extra time at the start before the mushrooms go down
    bool canGiveScore = true; //< check for no multiple end sequences

    void Start()
    {
        //getting all musroom platforms in the scene
        mushroomPlatforms = GameObject.FindGameObjectsWithTag("MushroomPlatform");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        mushroomSpeed = 10;
        goDownCooldown = 3;
        goDownTimer = -3;
        canGiveScore = true;
    }

    void Update()
    {
        //timer counter & the down event starter
        if (goDownTimer < goDownCooldown)
        {
            goDownTimer += Time.deltaTime;
        }
        else
        {
            StartCoroutine(MushroomDownEvent());
            goDownTimer = -100;
        }

        //check if there is one 1 player over
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length == 1 && canGiveScore)
        {
            //sets bool on false so this if can't happen again
            canGiveScore = false;
            //check for which player is to one over and gives points in the score manager
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
            //ending of the minigame
            StartCoroutine(EndMoment());
        }
    }

    IEnumerator EndMoment()
    {
        //cam zoomin on the winner
        CamZoomToWinner.Instance.StartZooming(players[0]);
        //countdown for winning the game
        yield return new WaitForSeconds(5);
        //loading the main island scene and activating all players
        SceneManager.LoadScene("MarkMain");
        CosmeticsSpawner.Instance.ActivatePlayers();
    }

    IEnumerator MushroomDownEvent()
    {
        //sets the mushroom that doesnt go down
        int tempStableMushroom = Random.Range(0, mushroomPlatforms.Length);
        //sets a mushroom to check the hight of and is not the musroom that doesnt go down
        int tempMushroomHeightChecker = Mathf.Abs(tempStableMushroom / 2 + 2);
        if (tempMushroomHeightChecker == tempStableMushroom)
        {
            tempMushroomHeightChecker += 1;
        }

        //all mushrooms but 1 goes down untill under the water
        while (mushroomPlatforms[tempMushroomHeightChecker].transform.position.y > -12)
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

        //all mushrooms but 1 goes up untill the height of the one that didnt move
        while (mushroomPlatforms[tempMushroomHeightChecker].transform.position.y < -1)
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
        //resets the timer for going down
        goDownTimer = 0;
        //makes the minigame harder
        mushroomSpeed += 5;
    }
}
