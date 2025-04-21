using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsValueContainer : MonoBehaviour
{
    // abandoned script
    public float brightnessValue;

    public static SettingsValueContainer Instance { get; set; }

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

    public void setBrightness(float value)
    {
        brightnessValue = value;
    }
}
