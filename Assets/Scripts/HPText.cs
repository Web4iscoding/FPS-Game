using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class HPText : MonoBehaviour
{
    Transform mainCamera;
    Transform unit;
    Transform canvas;
    public Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        // handling of HP UI's parents between the enemy and the display Canva
        if (transform != null)
        {
            mainCamera = Camera.main.transform;
            unit = transform.parent;
            canvas = GameObject.FindWithTag("EnemyHealth").transform;
            transform.SetParent(canvas);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // attaching and positioning of HP UI to enemy
        if (transform != null)
            transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.transform.position);
            transform.position = unit.position + offset;
    }
}
