using System.Collections;
using UnityEngine;

public class Ghost : MonoBehaviour, Spawnable
{
    private const float SPAWN_SPEED = 0.05f;
  
    private Vector3 originalPosition;
    public AudioSource audioSource;
    public GameObject model;
    public GameObject light;
    public Animator animator;

    public void Start()
    {
        originalPosition = transform.localPosition;
        animator = gameObject.GetComponent<Animator>();
        Reset();
    }

    public void Zap()
    {
        //Debugging.Use(() => {
        //    Reset();
        //    Game.Instance().AddScore(10);
        //});

        audioSource.Play();
        //animator.SetTrigger("Death");
        //Reset();
        Game.Instance().AddScore(10);
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
        model.SetActive(true);
        light.SetActive(true);
        Rise();
        audioSource.Play();
        //animator.SetBool("IsDead", true);
    }

    public bool IsSpawned()
    {
        //return gameObject.activeSelf;
        return model.activeSelf;
    }

    private void Rise()
    {
        StartCoroutine(RiseCoroutine());
    }

    private void Reset()
    {
        //gameObject.SetActive(false);
        model.SetActive(false);
        light.SetActive(false);
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
