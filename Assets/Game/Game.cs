using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance()
    {
        return FindObjectOfType<Game>();
    }

    public GameObject moonTemplate;
    public GameObject zapper;
    public GameObject crosshair;
    
    public int Score { get; private set; } = 0;

    public void Begin(Pose moonPose)
    {
        Score = 0;
        Instantiate(moonTemplate, moonPose.position, moonPose.rotation);
        Debugging.Log("Object spawned");

        zapper.SetActive(true);
        crosshair.SetActive(true);
        Debugging.Log("Set stuff to active!");
    }

    public void AddScore(int n) { Score += n; }
}
