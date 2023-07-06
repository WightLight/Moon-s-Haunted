using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public static Game Instance()
    {
        return FindObjectOfType<Game>();
    }

    public GameObject moonTemplate;
    private GameObject hauntedMoon;
    public GameObject zapper;
    public GameObject crosshair;
    public TMP_Text timerText;
    public TMP_Text scoreText;
    public TMP_Text finalScoreText;
    public TMP_Text instructionsText;
    public GameObject gameOverMenu;

    public bool isPlaying = false;
    public int Score { get; private set; } = 0;

    public float MaxTime = 30;
    public float TimeLeft = 30;

    private void Update()
    {
        if (TimeLeft > 0 && isPlaying)
        {
            TimeLeft -= Time.deltaTime;
            timerText.text = Mathf.Floor(TimeLeft).ToString() + " sec.";
        }
        else if(TimeLeft <= 0 && isPlaying) GameOver();
    }

    public void Begin(Pose moonPose)
    {
        isPlaying = true;
        Score = 0;
        TimeLeft = MaxTime;
        hauntedMoon = Instantiate(moonTemplate, moonPose.position, moonPose.rotation);
        Debugging.Log("Object spawned");

        zapper.SetActive(true);
        crosshair.SetActive(true);
        gameOverMenu.SetActive(false);
        timerText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        finalScoreText.gameObject.SetActive(true);
        instructionsText.gameObject.SetActive(false);
        Debugging.Log("Set stuff to active/inactive!");
    }

    public void GameOver()
    {
        isPlaying = false;
        zapper.SetActive(false);
        crosshair.SetActive(false);
        Destroy(hauntedMoon);
        gameOverMenu.SetActive(true);
        Debugging.Log("Game Over!");
        timerText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        finalScoreText.text = "Final Score: " + Score;
    }

    public void AddScore(int n) { Score += n; }
}
