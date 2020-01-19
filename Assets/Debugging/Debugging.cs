using System;
using UnityEngine;
using UnityEngine.UI;

public class Debugging : MonoBehaviour
{
    public static void Log(object text)
    {
        var textComponent = GameObject.Find("DebugText").GetComponent<Text>();
        textComponent.text = textComponent.text + "\n" + text.ToString();
    }

    public static void Use(Action action)
    {
        try {
            action();
        } catch(Exception e) {
            Log(e.Message + "\n" + e.StackTrace);
            throw e;
        }
    }
}
