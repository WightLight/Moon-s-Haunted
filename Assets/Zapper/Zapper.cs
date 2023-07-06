using System.Collections;
using System.Collections.Generic;
using System.Xml;
//using UnityEditorInternal;
using UnityEngine;

public class Zapper : MonoBehaviour
{
    public Camera camera;
    public AudioSource audio;
    public Animator animator;
    public GameObject beam;
    public GameObject blastEffect;

    public int heatLevel = 0;
    public int maxHeat = 100;

    void Update()
    {
        if (IsFirstTouchDetected() && Game.Instance().isPlaying)
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

                    // Hit any ghost we aimed at.
                    if (objectHit.GetComponent<Ghost>() != null)
                    {
                        objectHit.GetComponent<Ghost>().Zap();
                    }

                    // If we hit something, stop the beam there. Otherwise stop at the normal distance.

                    if (objectHit != null)
                    {

                        blastEffect.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                        blastEffect.SetActive(true);
                    }

                }
                Vector3 beamScale = new Vector3(0f, 0f, 1f);
                beam.transform.localScale = beamScale;
                StartCoroutine(BeamCoroutine());
            }
        }
    }

    private void Start()
    {
        beam.SetActive(false);
        blastEffect.SetActive(false);
    }

    private bool IsFirstTouchDetected()
    {
        return (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            || Input.GetMouseButtonDown(0);
    }

    IEnumerator BeamCoroutine()
    {
        beam.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        beam.SetActive(false);
        blastEffect.SetActive(false);
    }    
}
