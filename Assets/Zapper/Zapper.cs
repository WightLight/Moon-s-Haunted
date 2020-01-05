using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zapper : MonoBehaviour
{

    public GameObject origin;

    void Update()
    {
        if (IsFirstTouchDetected())
        {
            print("Touch Detected");

            RaycastHit hit;
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            print(ray);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                print("Found an object to hit");
                Transform objectHit = hit.transform;
                print(objectHit);

                if (objectHit.GetComponent<Ghost>() != null)
                {
                    objectHit.GetComponent<Ghost>().Zap();
                }
            }
        }
    }

    private bool IsFirstTouchDetected()
    {
        return (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            || Input.GetMouseButtonDown(0);
    }
}
