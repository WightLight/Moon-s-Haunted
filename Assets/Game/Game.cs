using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject moonTemplate;
    public GameObject zapper;
    public GameObject crosshair;

    public void Begin(Pose moonPose)
    {
        Instantiate(moonTemplate, moonPose.position, moonPose.rotation);
        Debugging.Log("Object spawned");

        zapper.SetActive(true);
        crosshair.SetActive(true);
        Debugging.Log("Set stuff to active!");
    }
}
