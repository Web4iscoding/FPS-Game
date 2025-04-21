using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalReferences : MonoBehaviour
{
    // GlobalReferences Singleton

    public static GlobalReferences Instance { get; set; }

    public GameObject bulletImpactPrefab;

    public GameObject bloodSprayEffect;

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
}
