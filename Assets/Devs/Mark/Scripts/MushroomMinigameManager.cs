using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MushroomMinigameManager : MonoBehaviour
{
    GameObject[] mushroomPlatforms; // Array of mushroom platforms
    public GameObject[] players; // Array of players

    [SerializeField] float mushroomSpeed = 10; // Speed at which mushrooms descend
    [SerializeField] float goDownCooldown = 3; // Cooldown before mushrooms go down
    float goDownTimer = -3; // Timer for initial delay
    bool canGiveScore = true; // Flag to prevent multiple scoring

    void Start()
    {
        // Retrieve all mushroom platforms in the scene
        mushroomPlatforms = GameObject.FindGameObjectsWithTag("MushroomPlatform");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Resets variables when a new scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        mushroomSpeed = 10;
        goDownCooldown = 3;
        goDownTimer = -3;
        canGiveScore = true;
    }

    void Update()
    {
        // Update the goDownTimer and start the down event when ready
        if (goDownTimer < goDownCooldown)
        {
            goDownTimer += Time.deltaTime;
        }
        else
        {
            StartCoroutine(MushroomDownEvent());
            goDownTimer = -100;
        }

        // Check if only one player remains
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length == 1 && canGiveScore)
        {
            canGiveScore = false;
            // Award points to the remaining player
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

    // Ends the minigame and returns to the main island
    IEnumerator EndMoment()
    {
        CamZoomToWinner.Instance.StartZooming(players[0]);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MarkMain");
        CosmeticsSpawner.Instance.ActivatePlayers();
    }

    // Handles the event where mushrooms go down and up
    IEnumerator MushroomDownEvent()
    {
        int tempStableMushroom = Random.Range(0, mushroomPlatforms.Length);
        int tempMushroomHeightChecker = Mathf.Abs(tempStableMushroom / 2 + 2);
        if (tempMushroomHeightChecker == tempStableMushroom)
        {
            tempMushroomHeightChecker += 1;
        }

        // Move mushrooms down except the stable one
        while (mushroomPlatforms[tempMushroomHeightChecker].transform.position.y > -12)
        {
            for (int i = 0; i < mushroomPlatforms.Length; i++)
            {
                if (tempStableMushroom != i)
                {
                    mushroomPlatforms[i].transform.position += Vector3.down * mushroomSpeed * Time.deltaTime;
                }
                yield return null;
            }
        }

        // Move mushrooms up except the stable one
        while (mushroomPlatforms[tempMushroomHeightChecker].transform.position.y < -1)
        {
            for (int i = 0; i < mushroomPlatforms.Length; i++)
            {
                if (tempStableMushroom != i)
                {
                    mushroomPlatforms[i].transform.position += Vector3.up * mushroomSpeed * Time.deltaTime;
                }
                yield return null;
            }
        }

        // Reset timer and increase difficulty
        goDownTimer = 0;
        mushroomSpeed += 5;
    }
}
