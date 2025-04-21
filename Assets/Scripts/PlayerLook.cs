using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{

    public Camera cam;
    private float xRotation = -0f;

    // Sensitivity
    public float xSen = 30f;
    public float ySen = 30f;
    
    void Update()
    {
        // getting the manipulated DPI value from PlayerPrefs and passing values
        xSen = PlayerPrefs.GetFloat("DPI");
        ySen = PlayerPrefs.GetFloat("DPI");
    }


    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        // Calculate camera rotation for looking up down
        xRotation -= (mouseY* Time.deltaTime) * ySen;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        // Apply calculation to transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        // Rotate player to left and right via transform
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSen);
    }
}
