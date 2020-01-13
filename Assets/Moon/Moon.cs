﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class Moon : MonoBehaviour
{
    public Camera firstPersonCamera;
    private Anchor anchor;
    private DetectedPlane detectedPlane;
    private float yOffset;

    [SerializeField] private Config config;
    public void Start()
    {
        StartCoroutine(SteadyRotation(config.rotationSpeed));

        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.enabled = false;
        }
    }

    private void Update()
    {
        // The tracking state must be FrameTrackingState.Tracking
        // in order to access the Frame.
        if (Session.Status != SessionStatus.Tracking)
        {
            return;
        }

        // If there is no plane, then return
        if (detectedPlane == null)
        {
            return;
        }

        // Check for the plane being subsumed.
        // If the plane has been subsumed switch attachment to the subsuming plane.
        while (detectedPlane.SubsumedBy != null)
        {
            detectedPlane = detectedPlane.SubsumedBy;
        }

        // Make the moon face the viewer.
        //transform.LookAt(firstPersonCamera.transform);

        // Move the position to stay consistent with the plane.
        transform.position = new Vector3(transform.position.x,
                    detectedPlane.CenterPose.position.y + yOffset, transform.position.z);
    }

    public void SetSelectedPlane(DetectedPlane detectedPlane)
    {
        this.detectedPlane = detectedPlane;
        CreateAnchor();
    }

    void CreateAnchor()
    {
        // Create the position of the anchor by raycasting a point towards
        // the middle of the screen.
        Vector2 pos = new Vector2(Screen.width * .5f, Screen.height * .5f);
        Ray ray = firstPersonCamera.ScreenPointToRay(pos);
        Vector3 anchorPosition = ray.GetPoint(5f);

        // Create the anchor at that point.
        if (anchor != null)
        {
            DestroyObject(anchor);
        }
        anchor = detectedPlane.CreateAnchor(new Pose(anchorPosition, Quaternion.identity));

        // Attach the moon to the anchor.
        transform.position = anchorPosition;
        transform.SetParent(anchor.transform);

        // Record the y offset from the plane.
        yOffset = transform.position.y - detectedPlane.CenterPose.position.y;

        // Finally, enable the renderers.
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.enabled = true;
        }
    }

    public IEnumerator SteadyRotation(float rotationSpeed)
    {
        while(true)
        {
            transform.Rotate(Vector3.up, rotationSpeed);
            yield return null;
        }
    }

    [System.Serializable] public class Config
    {
        public float rotationSpeed = 0.1f;
    }
}
