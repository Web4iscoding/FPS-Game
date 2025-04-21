using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public Slider brightnessSlider;

    public PostProcessProfile brightness;
    public PostProcessLayer layer;

    public AutoExposure exposure;

    private float brightnessValue;
    public TextMeshProUGUI brightnessValueText;

    void Start()
    {
        // getting the manipulated brightness value from PlayerPrefs and passing values
        brightness.TryGetSettings(out exposure);
        brightnessValue = PlayerPrefs.GetFloat("brightness");
        AdjustBrightness(brightnessValue);
        brightnessValueText.text = $"{brightnessValue}";
        brightnessSlider.value = brightnessValue;
    }

    public void AdjustBrightness(float value)
    {
        // adjusting brighness based on slider
        if (value != 0)
        {
            exposure.keyValue.value = value;
            PlayerPrefs.SetFloat("brightness", value);
            brightnessValueText.text = $"{value}";
        }
        else {
            exposure.keyValue.value = .05f;
            PlayerPrefs.SetFloat("brightness", .05f);
            brightnessValueText.text = "0.05";
        }
    }
}
