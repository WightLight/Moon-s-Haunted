using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject gameObjectToInstantiate;

    private GameObject spawnedObject;
    public Zapper zapper;
    private ARPlaneManager arPlaneManager;
    private ARRaycastManager arRaycastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        arPlaneManager = GetComponent<ARPlaneManager>();

        StartCoroutine(PlaceMoon());
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    private IEnumerator PlaceMoon()
    {
        while(!TryGetTouchPosition(out Vector2 touchPosition) || !arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
            yield return null;
        
        Debugging.Use(() => {
            Debugging.Log("Hit detected!");
            var hitPose = hits[0].pose;
            if (spawnedObject == null)
            {
                StartGame(hitPose);
            }
        });
    }

    void StartGame(Pose hitPose)
    {
        spawnedObject = Instantiate(gameObjectToInstantiate, hitPose.position, hitPose.rotation);
        Debugging.Log("Object spawned");

        zapper.gameObject.SetActive(true);
        Debugging.Log("Started zapper active!");

        arPlaneManager.enabled = false;
        Debugging.Log("Started arPlaneManager inactive!");

        spawnedObject.SetActive(true);
        Debugging.Log("Started spawnedObject active!");
    }
}
