using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour, Spawnable
{
    private const float SPAWN_SPEED = 0.05f;
  
    private Vector3 originalPosition;

    private AudioSource audioSource;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Start()
    {
        originalPosition = transform.localPosition;
        Reset();
    }

    public void Zap()
    {
        Reset();
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
        Rise();
        audioSource.Play();
    }

    public bool IsSpawned()
    {
        return gameObject.activeSelf;
    }

    private void Rise()
    {
        StartCoroutine(RiseCoroutine());
    }

    private void Reset()
    {
        gameObject.SetActive(false);
        transform.localPosition = originalPosition;
    }

    private IEnumerator RiseCoroutine()
    {
        float t = 0;
        Vector3 newPosition = originalPosition + transform.localScale.x * (transform.localRotation * Vector3.up);

        while(t < 1)
        {
            t += SPAWN_SPEED;
            transform.localPosition = Vector3.Lerp(originalPosition, newPosition, t);
            yield return null;
        }
    }
}
