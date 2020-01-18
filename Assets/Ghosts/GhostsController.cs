using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostsController : MonoBehaviour
{
    public Moon moon;
    private Spawner<Ghost> ghostSpawner;

    void Awake()
    {
        ghostSpawner = new Spawner<Ghost>(new List<Ghost>(moon.GetComponentsInChildren<Ghost>()));
    }

    void Update()
    {
        ghostSpawner.Update(Time.deltaTime);
    }
}
