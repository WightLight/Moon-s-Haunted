using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debugging : MonoBehaviour
{
    public static void Log(object text)
    {
        GameObject.Find("DebugText").GetComponent<Text>().text = text.ToString();
    }
}
