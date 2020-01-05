using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    [SerializeField] private Config config;
    public void Start()
    {
        StartCoroutine(SteadyRotation(config.rotationSpeed));
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
