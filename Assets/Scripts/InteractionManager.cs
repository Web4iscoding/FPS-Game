using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    // InteractionManager Singleton

    public static InteractionManager Instance { get; set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        // Raycast to track main camera position
        if(Physics.Raycast(ray, out hit))
        {
            GameObject objectHit = hit.transform.gameObject;

            if (objectHit.CompareTag("Target"))
            {
                print("Target being aimed at");
            }
        }

    }
}
