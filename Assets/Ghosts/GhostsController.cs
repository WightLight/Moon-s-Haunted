using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostsController : MonoBehaviour
{
    public Moon moon;
    private List<Ghost> ghosts;

    void Start()
    {
        ghosts = new List<Ghost>(moon.GetComponentsInChildren<Ghost>());
    }

    void Update()
    {
        if(NumberOfActiveGhosts() < 1) ghosts[1].Spawn();
    }

    public int NumberOfActiveGhosts()
    {
        return ghosts.FindAll(ghost => ghost.gameObject.activeSelf).Count;
    }
}
