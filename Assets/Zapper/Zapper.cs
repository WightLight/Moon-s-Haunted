using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zapper : MonoBehaviour
{
    public Camera camera;
    public AudioSource audio;
    public Animator animator;

    public int heatLevel = 0;
    public int maxHeat = 100;

    void Update()
    {
        if (IsFirstTouchDetected())
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Reload"))
            {
                audio.Play();
                animator.Play("Shoot", 0, 0);

                heatLevel += 10;
                if (heatLevel >= maxHeat)
                {
                    heatLevel = 0;
                    animator.Play("Reload", 0, 0);
                }

                RaycastHit hit;
                Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    Transform objectHit = hit.transform;

                    if (objectHit.GetComponent<Ghost>() != null)
                    {
                        objectHit.GetComponent<Ghost>().Zap();
                    }
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
