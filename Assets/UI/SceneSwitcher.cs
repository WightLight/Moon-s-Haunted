﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Switch to a different scene
    public void SwitchToScene(string sceneName)
    {
        print("Thing!");
        SceneManager.LoadScene(sceneName);
    }
}
