using System;
using UnityEngine;
using UnityEngine.UI;

public class Debugging : MonoBehaviour
{
    public static void Log(object text)
    {
        GameObject.Find("DebugText").GetComponent<Text>().text = text.ToString();
    }

    public static void Use(Action action)
    {
        try {
            action();
        } catch(Exception e) {
            GameObject.Find("DebugText").GetComponent<Text>().text = e.Message + "\n" + e.StackTrace;
        }
    }
}
