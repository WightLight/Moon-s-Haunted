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
            timerText.text = TimeLeft.ToString() + "sec.";
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
        Debugging.Log("Set stuff to active/inactive!");
    }

    public void GameOver()
    {
        isPlaying = false;
        Destroy(hauntedMoon);
        gameOverMenu.SetActive(true);
        Debugging.Log("Game Over!");
    }

    public void AddScore(int n) { Score += n; }
}
