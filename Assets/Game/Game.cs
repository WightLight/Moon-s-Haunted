using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject moonTemplate;
    public Zapper zapper;

    public void Begin(Pose moonPose)
    {
        Instantiate(moonTemplate, moonPose.position, moonPose.rotation);
        Debugging.Log("Object spawned");

        zapper.gameObject.SetActive(true);
        Debugging.Log("Started zapper active!");
    }
}
